using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Model;
using SchoolManagementApi.Context;
using SchoolManagementApi.Migrations;
using SchoolManagementApi.Model;

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
            var TeacherId = 0;
            db.Database.ExecuteSqlRaw($"Exec AddUser '{a.StudentUser}','{a.Studentpass}','{urole}','{a.StudentId}','{TeacherId}'");
            return Ok("Student Added successfully..!!!");
        }


        [Route("AddTeacher")]
        [HttpPost]
        public IActionResult AddTeacher(AddTeacher t)
        {
            t.Joindate = DateTime.Now.ToString();
            db.Database.ExecuteSqlRaw($"exec AddTeachers '{t.TeacherUser}','{t.Teacherpass}','{t.TecherName}','{t.Subject}','{t.Standard}','{t.TeacherEmail}','{t.Contact}','{t.qualification}','{t.Joindate}','{t.Salary}'");
            var urole = "Teacher";
            db.Database.ExecuteSqlRaw($"Exec AddUser '{t.TeacherUser}','{t.Teacherpass}','{urole}'");
            return Ok("Teacher Added successfully");

        }

        //[Route("GetLeaveRequest")]
        //[HttpGet]
        //public IActionResult GetLeaveRequest() 
        //{
        //    var data = db.TeacherLeaveRequest.ToList();
        //    return Ok(data);
        //}
    }
}
