using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost]
        public IActionResult StudentRequestDelete(int id)
        {
            var data = db.studentRequests.FirstOrDefault(x => x.studentRequestId == id);

            if (data != null)
            {
                db.studentRequests.Remove(data);
                db.SaveChanges();
                return Ok("Request deleted successfully");
            }

            return NotFound("Request not found");
        }
    }
}
