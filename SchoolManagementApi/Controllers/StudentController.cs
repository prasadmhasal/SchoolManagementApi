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
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public StudentController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("Profile/{Username}")]
        [HttpGet]
        public IActionResult StudentProfile(string Username)
        {
            var data = db.Student.FromSqlRaw($"exec StudentProfile '{Username}'").AsEnumerable().SingleOrDefault();
            return Ok(data);
        }

        [Route("UpdateFeesStatus")]
        [HttpPut]
        public IActionResult UpdateFeesStatus(string StudentUser, UpdateFeeStatusModel model)
        {
            var student = db.Student.FirstOrDefault(s => s.StudentUser == StudentUser);

            if (student == null)
            {
                return NotFound(new { success = false, message = "Student not found" });
            }

            // Only update the fee status
            student.FeesStatus = model.FeesStatus ?? student.FeesStatus;
            db.SaveChanges();

            return Ok(new { success = true });
        }
    }
}
