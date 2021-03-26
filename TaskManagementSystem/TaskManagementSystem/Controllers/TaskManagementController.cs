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
            try
            {               
                var a = DataAccess.Instance.CommonServices.IsExist("Task_Project", "ProjectName = '" + project.ProjectName + "' ");
                if (a)
                {
                    throw new Exception("Project Already Exist.");
                }
                _context.Project.Add(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {                
                cr.message = ex.Message;
                cr.results = Constant.FAILED;
            }            
            return new JsonResult(cr);
        }
        [HttpPut]
        public JsonResult UpdateProject(Project project)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.Project.Where(e => e.Id == project.Id).FirstOrDefault();
                pro.ProjectName = project.ProjectName;
                pro.ExpireDate = project.ExpireDate;
                pro.IsSupport = project.IsSupport;
                _context.Project.Update(project);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                cr.message = ex.Message;
                cr.results = Constant.FAILED;
            }
            return new JsonResult(cr);
        }
        [HttpDelete]
        public JsonResult deleteProject(int id)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.Project.Where(e => e.Id == id).FirstOrDefault();               
                _context.Project.Remove(pro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                cr.message = ex.Message;
                cr.results = Constant.FAILED;
            }
            return new JsonResult(cr);
        }
        #endregion
    }
}
