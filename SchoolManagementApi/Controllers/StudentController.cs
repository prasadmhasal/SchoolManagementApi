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



        [Route("UpdateFeesStatus/{studentUser}")]
        [HttpPut]
        public IActionResult UpdateFeesStatus(string studentUser )
        {
            db.Database.ExecuteSqlRaw($"Exec UpdateFees '{studentUser}'");
            // Check if the studentUser and feesStatus are not null or empty
            return Ok();
        }
    }
}
