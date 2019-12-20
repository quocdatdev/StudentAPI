using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIDemo.Models;
using APIDemo.Filter;

namespace APIDemo.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private StudentDBContext db = new StudentDBContext();

        [Route("")]
        public IHttpActionResult GetAll()
        {
            var std = db.Students.ToList();
            return Ok(std);
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            var std = db.Students.FirstOrDefault(x => x.ID == id);
            if(std == null)
            {
                return Content(HttpStatusCode.NotFound, "Student with id " + id.ToString() + " not found");
            }
            return Ok(std);
        }

        [HttpPost, Route("insert")]
        public IHttpActionResult InsertStudent([FromBody]Student student)
        {
            if(!ModelState.IsValid)
            {
                string msg = string.Empty;
                throw new MyException("Internal Server Error");
            }
            db.Students.Add(student);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut, Route("update/{id}")]
        public IHttpActionResult UpdateStudent(int id, [FromBody]Student student)
        {
            try
            {
                var std =  db.Students.FirstOrDefault(x => x.ID == id);
                if(std == null)
                {
                    return Content(HttpStatusCode.NotFound, "Student with id " + id.ToString() + " not found");
                }
                else
                {
                    std.Name = student.Name;
                    std.Mail = student.Mail;
                    std.Phone = student.Phone;
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete, Route("delete/{id}")]
        public IHttpActionResult DeleteStudent(int id)
        {
            try
            {
                var std = db.Students.FirstOrDefault(x => x.ID == id);
                if(std == null)
                {
                    return Content(HttpStatusCode.NotFound, "Student with id " + id.ToString() + " not found");
                }
                else
                {
                    db.Students.Remove(std);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
