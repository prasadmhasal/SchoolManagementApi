using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Model;
using SchoolManagementApi.Context;

namespace SchoolManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public AdminController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("GetStudentRequest")]
        [HttpGet]
        public IActionResult GetStudentRequest()
        {
            var data = db.studentRequests.ToList();
            return Ok(data);
        }

        [Route("StudentRequestDelete/{id}")]
        [HttpDelete]
        public IActionResult StudentRequestDelete(int id)
        {
            
            var data = db.studentRequests.Find(id);

            if (data != null)
            {
                db.studentRequests.Remove(data);
                db.SaveChanges();
                return Ok("Request deleted successfully");
            }

            return NotFound("Request not found");
        }


        [Route("AddStudent")]
        [HttpPost]
        public IActionResult AddStudent(AddStudent a)
        {
            a.AddMisstiondate = DateTime.Now.ToString();
            db.Database.ExecuteSqlRaw($"EXEC ADDSTUDENT '{a.StudentUser}','{a.Studentpass}','{a.fullname}','{a.Email}','{a.Contect}','{a.Standard}','{a.AddMisstiondate}'");
            var urole = "Student";
            db.Database.ExecuteSqlRaw($"Exec AddUser '{a.StudentUser}','{a.Studentpass}','{urole}'");
            return Ok("Student Added successfully..!!!");
        }
    }
}
