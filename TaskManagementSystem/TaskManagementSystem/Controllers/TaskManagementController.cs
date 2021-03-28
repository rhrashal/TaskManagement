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
    
    [ApiController]
    [Authorize]
    public class TaskManagementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TaskManagementController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("[controller]/[action]")]
        [HttpGet]
        public ActionResult<List<Country>> GetUser()
        {
            return _context.Country.ToList();
        }

        #region Project
        [HttpGet]
        [Route("[controller]/[action]")]
        public JsonResult GetAllProject() 
        {

            CommonResponse cr = new CommonResponse();
            cr.results = _context.Project.Where(e => e.IsDeleted == false).ToList();
            return new JsonResult(cr);
        }
        [HttpPost]
        [Route("[controller]/[action]")]
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
                project.AddDate = DateTime.Now;
                project.AddBy = User.Identity.Name;
                project.SetDate();
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
        [Route("TaskManagement/UpdateProject/{id}")]
        public JsonResult UpdateProject(int id, Project project)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.Project.Where(e => e.Id == id).FirstOrDefault();
                pro.ProjectName = project.ProjectName;
                pro.ExpireDate = project.ExpireDate;
                pro.IsSupport = project.IsSupport;
                pro.UpdateDate = DateTime.Now;
                pro.UpdateBy = User.Identity.Name;
                pro.SetDate();
                _context.Project.Update(pro);
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
        [Route("TaskManagement/deleteProject/{id}")]
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

        #region Sprint
        [HttpGet]
        [Route("[controller]/[action]")]
        public JsonResult GetAllSprint()
        {
            CommonResponse cr = new CommonResponse();
            cr.results = from s in _context.Sprint
                         join p in _context.Project on s.ProjectId equals p.Id
                         select new { Id = s.Id, SprintTitle = s.SprintTitle, StartDate = s.StartDate,  EndDate = s.EndDate, 
                             Status = s.Status,  IsSupport = s.IsSupport, ProjectId = p.Id, ProjectName = p.ProjectName };
            return new JsonResult(cr);
        }
        [HttpPost]
        [Route("[controller]/[action]")]
        public JsonResult AddSprint(Sprint sprint)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var a = DataAccess.Instance.CommonServices.IsExist("Task_Sprint", "SprintTitle = '" + sprint.SprintTitle + "' ");
                if (a)
                {
                    throw new Exception("Sprint Already Exist.");
                }
                sprint.AddDate = DateTime.Now;
                sprint.AddBy = User.Identity.Name;
                sprint.SetDate();
                _context.Sprint.Add(sprint);
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
        [Route("TaskManagement/UpdateSprint/{id}")]
        public JsonResult UpdateSprint(int id, Sprint sprint)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.Sprint.Where(e => e.Id == id).FirstOrDefault();
                pro.ProjectId = sprint.ProjectId;
                pro.SprintTitle = sprint.SprintTitle;
                pro.StartDate = sprint.StartDate;
                pro.EndDate = sprint.EndDate;
                pro.Status = sprint.Status;
                pro.UpdateDate = DateTime.Now;
                pro.UpdateBy = User.Identity.Name;
                pro.SetDate();

                _context.Sprint.Update(pro);
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
        [Route("TaskManagement/deleteSprint/{id}")]
        public JsonResult deleteSprint(int id)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.Sprint.Where(e => e.Id == id).FirstOrDefault();
                _context.Sprint.Remove(pro);
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
