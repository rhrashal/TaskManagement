using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TaskManagementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TaskManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Country>> GetUser()
        {
            return _context.Country.ToList();
        }

        #region Project
        [HttpGet]
        public JsonResult GetAllProject() 
        {
            CommonResponse cr = new CommonResponse();
            cr.results = _context.Project.Where(e => e.IsDeleted == false).ToList();
            return new JsonResult(cr);
        }
        [HttpPost]
        public JsonResult AddProject( Project project)
        {
            CommonResponse cr = new CommonResponse();
            var a = DataAccess.Instance.CommonServices.IsExist("Task_Project", "ProjectName =" + project.ProjectName);
            cr.results = _context.Project.Add(project);

            return new JsonResult(cr);
        }

        #endregion
    }
}
