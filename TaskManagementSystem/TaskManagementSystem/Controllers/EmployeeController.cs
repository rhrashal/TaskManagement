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
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Employee Category
        [HttpGet]
        [Route("Employee/GetAllCategory")]
        public JsonResult GetAllCategory()
        {
            CommonResponse cr = new CommonResponse();
            cr.results = _context.EmpCategory.Where(e => e.IsDeleted == false).ToList();
            return new JsonResult(cr);
        }
        [HttpPost]
        [Route("Employee/AddCategory")]
        public JsonResult AddCategory([FromBody] EmpCategory category)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var isExist = DataAccess.Instance.CommonServices.IsExist("Emp_Category", "CategoryName = '" + category.CategoryName + "' ");
                if (isExist)
                {
                    throw new Exception("Category Already Exist.");
                }
                category.AddDate = DateTime.Now;
                category.AddBy = User.Identity.Name;
                category.SetDate();
                _context.EmpCategory.Add(category);
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
        [Route("Employee/UpdateCategory")]
        public JsonResult UpdateCategory(EmpCategory category)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.EmpCategory.Where(e => e.CategoryID == category.CategoryID).FirstOrDefault();
                pro.CategoryName = category.CategoryName;
                pro.CategoryIsTeacher = category.CategoryIsTeacher;
                pro.UpdateDate = DateTime.Now;
                pro.UpdateBy = User.Identity.Name;
                pro.SetDate();
                _context.EmpCategory.Update(pro);
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
        [Route("Employee/DeleteCategory/{id}")]
        public JsonResult DeleteCategory(int id)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.EmpCategory.Where(e => e.CategoryID == id).FirstOrDefault();
                pro.IsDeleted = true;
                pro.UpdateDate = DateTime.Now;
                pro.UpdateBy = User.Identity.Name;                
                _context.EmpCategory.Update(pro);
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

        #region Employee Department
        [HttpGet]
        [Route("Employee/GetAllDepartment")]
        public JsonResult GetAllDepartment()
        {
            CommonResponse cr = new CommonResponse();
            cr.results = _context.EmpDepartment.Where(e => e.IsDeleted == false).ToList();
            return new JsonResult(cr);
        }
        [HttpPost]
        [Route("Employee/AddDepartment")]
        public JsonResult AddDepartment([FromBody] EmpDepartment department)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var isExist = DataAccess.Instance.CommonServices.IsExist("Emp_Department", "DepartmentName = '" + department.DepartmentName + "' ");
                if (isExist)
                {
                    throw new Exception("Department Already Exist.");
                }
                department.AddDate = DateTime.Now;
                department.AddBy = User.Identity.Name;
                department.SetDate();
                _context.EmpDepartment.Add(department);
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
        [Route("Employee/UpdateDepartment")]
        public JsonResult UpdateDepartment(EmpDepartment department)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.EmpDepartment.Where(e => e.DepartmentID == department.DepartmentID).FirstOrDefault();
                pro.DepartmentName = department.DepartmentName;
                pro.DisOrder = department.DisOrder;
                pro.UpdateDate = DateTime.Now;
                pro.UpdateBy = User.Identity.Name;
                pro.SetDate();
                _context.EmpDepartment.Update(pro);
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
        [Route("Employee/DeleteDepartment/{id}")]
        public JsonResult DeleteDepartment(int id)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.EmpDepartment.Where(e => e.DepartmentID == id).FirstOrDefault();
                pro.IsDeleted = true;
                pro.UpdateDate = DateTime.Now;
                pro.UpdateBy = User.Identity.Name;
                _context.EmpDepartment.Update(pro);
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

        #region Employee Designation
        [HttpGet]
        [Route("Employee/GetAllDesignation")]
        public JsonResult GetAllDesignation()
        {
            CommonResponse cr = new CommonResponse();
            cr.results = _context.EmpDesignation.Where(e => e.IsDeleted == false).ToList();
            return new JsonResult(cr);
        }
        [HttpPost]
        [Route("Employee/AddDesignation")]
        public JsonResult AddDesignation([FromBody] EmpDesignation designation)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var isExist = DataAccess.Instance.CommonServices.IsExist("Emp_Designation", "DesignationName = '" + designation.DesignationName + "' ");
                if (isExist)
                {
                    throw new Exception("Designation Already Exist.");
                }
                designation.AddDate = DateTime.Now;
                designation.AddBy = User.Identity.Name;
                designation.SetDate();
                _context.EmpDesignation.Add(designation);
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
        [Route("Employee/UpdateDesignation")]
        public JsonResult UpdateDesignation(EmpDesignation designation)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.EmpDesignation.Where(e => e.DesignationID == designation.DesignationID).FirstOrDefault();
                pro.DesignationName = designation.DesignationName;
                pro.DesignationOrder = designation.DesignationOrder;
                pro.CategoryID = designation.CategoryID;
                pro.UpdateDate = DateTime.Now;
                pro.UpdateBy = User.Identity.Name;
                pro.SetDate();
                _context.EmpDesignation.Update(pro);
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
        [Route("Employee/DeleteDesignation/{id}")]
        public JsonResult DeleteDesignation(int id)
        {
            CommonResponse cr = new CommonResponse();
            try
            {
                var pro = _context.EmpDesignation.Where(e => e.DesignationID == id).FirstOrDefault();
                pro.IsDeleted = true;
                pro.UpdateDate = DateTime.Now;
                pro.UpdateBy = User.Identity.Name;
                _context.EmpDesignation.Update(pro);
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
