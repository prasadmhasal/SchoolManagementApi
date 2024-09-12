using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Model;
using SchoolManagementApi.Context;

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

            
                db.studentRequests.Remove(data);
                db.SaveChanges();
                return Ok("Request deleted successfully");
            

            
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

        [Route("Addlabrarian")]
        [HttpPost]
        public IActionResult Addlabrarian(AddLibrarian l)
        {
            l.Joindate = DateTime.Now.ToString();
            db.Database.ExecuteSqlRaw($"Exec AddLibrarian '{l.LibrarianUser}','{l.Librarianpass}','{l.LibrarianName}','{l.Email}','{l.Contact}','{l.Joindate}','{l.Salary}'");
            var urole = "labrarian";
            db.Database.ExecuteSqlRaw($"Exec AddUser '{l.LibrarianUser}','{l.Librarianpass}','{urole}'");
            return Ok("Labrarian added successfully ");
        }

        [Route("SignIn")]
        [HttpPost]
        public IActionResult SignIn(Users u )
        {
            var data = db.Users.FromSqlRaw($"AuthUser '{u.UserName}','{u.Password}'").AsEnumerable().FirstOrDefault();

            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return Unauthorized("Invalid username or password"); 
            }
        }

        [Route("GetLeaveRequest")]
        [HttpGet]
        public IActionResult GetLeaveRequest()
        {
            var data = db.TeacherLeaves.ToList();
            return Ok(data);
        }

        [Route("PostLeaveRequest/{TeacherId}")]
        [HttpDelete]
        public IActionResult PostLeaveRequest(int TeacherId)
        {
            //db.Database.ExecuteSqlRaw($"Exec deleteTeacherLeave '{TeacherId}'");
            //return Ok("Update Successfully ");

            var data = db.TeacherLeaves.Find(TeacherId);

            if (data != null)
            {
                db.TeacherLeaves.Remove(data);
                db.SaveChanges();
                return Ok("Request deleted successfully");
            }

            return NotFound("Request not found");
        }

    }
}
