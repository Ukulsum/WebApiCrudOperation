using AspWebApiCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspWebApiCrudOperation.Controllers
{
    public class CrudApiController : ApiController
    {
        Web_Api_CRUD_dbEntities db = new Web_Api_CRUD_dbEntities();

        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var emp = db.Employees.Where(m => m.ID == id).FirstOrDefault();
            return Ok(emp);
        }

        [HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //var emp = db.Employees.Where(model => model.ID == e.ID).FirstOrDefault();
            //if(emp != null)
            //{
            //    emp.ID = e.ID;
            //    emp.Name = e.Name;
            //    emp.Gender = e.Gender;
            //    emp.Age = e.Age;
            //    emp.Designation = e.Designation;
            //    emp.Salary = e.Salary;

            //    db.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}
                
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = db.Employees.Where(model => model.ID == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }

    }
}
