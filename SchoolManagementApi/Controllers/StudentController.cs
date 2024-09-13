using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Context;

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
    }
}
