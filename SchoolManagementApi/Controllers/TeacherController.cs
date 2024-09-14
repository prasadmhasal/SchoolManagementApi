using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Context;
using SchoolManagementApi.Model;

namespace SchoolManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public TeacherController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("TeacherProfile/{Username}")]
        [HttpGet]
        public IActionResult TeacherProfile(string Username)
        {
            var data = db.Teachers.FromSqlRaw($"exec  TeacherProfile '{Username}'").AsEnumerable().SingleOrDefault();
           
            return Ok(data);
        }

        [Route("RequestLeave")]
        [HttpPost]
        public IActionResult TeacherRequestLeave(TeacherLeaveRequest e)
        {
            e.Status = "Pending";
            db.TeacherLeaves.Add(e);
            db.SaveChanges();
            return Ok("We will get in touch with you soon!");
        }
    }
}
