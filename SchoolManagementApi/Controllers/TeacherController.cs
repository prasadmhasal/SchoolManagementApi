using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Context;

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

    }
}
