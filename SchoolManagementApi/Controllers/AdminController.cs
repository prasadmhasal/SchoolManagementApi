using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolManagement.Model;
using SchoolManagementApi.Context;

using SchoolManagementApi.Model;
using System.Xml;

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
            return Ok("student request no found ");



        }


        [Route("AddStudent")]
        [HttpPost]
        public IActionResult AddStudent(AddStudent a)
        {
            a.AddMisstiondate = DateTime.Now.ToString();
            a.FeesStatus = "Pending";
            db.Database.ExecuteSqlRaw($"EXEC ADDSTUDENT '{a.StudentUser}','{a.Studentpass}','{a.fullname}','{a.Email}','{a.Contect}','{a.Standard}','{a.AddMisstiondate}','{a.Fees}','{a.FeesStatus}'");
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
            db.Database.ExecuteSqlRaw($"Exec AddSubject '{t.Subject}'");
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
        public IActionResult SignIn(Users u)
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

        [Route("PostLeaveRequest/{Id}")]
        [HttpDelete]
        public IActionResult PostLeaveRequest(int Id)
        {


            db.Database.ExecuteSqlRaw($"Exec deleteTeacherLeave '{Id}'");
            return Ok("Teacher LeaveRequest Deleted ");

        }

        [Route("GetEvents")]
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await db.Event.ToListAsync();
            return Ok(events);
        }
        [Route("CreateEvent")]
        [HttpPost]
        public async Task<IActionResult> createEvents(Event events)
        {
            db.Event.Add(events);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvents), new { id = events.Id }, events);
        }
        [Route("GetEventsById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetEventsById(int id)
        {
            var eventItem = await db.Event.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return Ok(eventItem);
        }
        [Route("updateEvent/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateEvent(int id, Event eventItem)
        {
            if (id != eventItem.Id)
            {
                return BadRequest();
            }
            db.Entry(eventItem).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return NoContent();
        }
        [Route("DeleteEvent/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var events = await db.Event.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            db.Event.Remove(events);
            await db.SaveChangesAsync();
            return NoContent();
        }



        [Route("AddTimeTable")]
        [HttpPost]

        public IActionResult AddTime(Timetable tt)
        {
            db.Timetables.Add(tt);
            db.SaveChanges();
            return Ok("TimeTable Added Successfully");
        }

        [Route("GetTimeTable")]
        [HttpGet]
        public IActionResult GetTime()
        {
            var curricula = db.Timetables.ToList();
            return Ok(curricula);
        }


        [Route("FetchSubject")]
        [HttpGet]
        public IActionResult FetchSubject()
        {
           var data = db.Subject.FromSqlRaw("exec fetchsubject").ToList();
            return Ok(data);
        }

        [Route("FetchClass")]
        [HttpGet]
        public IActionResult FetchClass()
        {
            var data = db.Teachers.FromSqlRaw("exec fetchClass").ToList();
            return Ok(data);
        }



        [Route("FeesPay/{StudentUse}")]
        [HttpGet]
        public IActionResult FeesPay(string StudentUse)
        {
            var data = db.Student.FromSqlRaw($"exec fetchFees '{StudentUse}'");
            return Ok(data);

        }
    }
}
