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

        [Route("GetAttendance/{Standard}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddStudent>>> GetAttendances(string Standard)
        {
          
            return await db.Set<AddStudent>().FromSqlRaw($"EXEC GetAllAttendances '{Standard}'").ToListAsync();
        }

        [Route("AssignAttendance")]
        [HttpPost]
        public IActionResult AddAttendance(List<Attendance> attendanceList)
        {
            if (attendanceList == null || !attendanceList.Any())
            {
                return BadRequest("No attendance data received.");
            }

            try
            {
                
                db.Attendances.AddRange(attendanceList);
                db.SaveChanges();
                return Ok("Attendance added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        [HttpGet("GetStudentById/{id}")]
        public IActionResult GetStudentById(int id)
        {
          
            var student = db.Student.Where(s => s.StudentId == id).AsEnumerable().SingleOrDefault();

            if (student == null)
            {
                return NotFound(new { message = "Student not found." });
            }

            return Ok(student); 
        }


        //[HttpPost("UploadFile")]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return BadRequest("No file selected.");

        //    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf", ".doc", ".docx" };
        //    if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
        //        return BadRequest("Invalid file format.");

        //    if (file.Length > 10 * 1024 * 1024) // 10 MB limit
        //        return BadRequest("File size exceeds the maximum limit.");

        //    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //    var filePath = Path.Combine(_uploadPath, uniqueFileName);
        //    Directory.CreateDirectory(_uploadPath);  // Ensure the upload directory exists

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    return Ok(new { fileName = uniqueFileName });
        //}
        //[HttpPost("AddAssignment")]
        //public async Task<IActionResult> AddAssignment([FromBody] AssignmentViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var assignment = new Assignments()
        //    {
        //        TeacherId = model.TeacherId,
        //        Standard = model.Standard,
        //        Title = model.Title,
        //        Description = model.Description,
        //        DueDate = model.DueDate,
        //        FileUpload = model.FileUpload
        //    };

        //    db.assignments.Add(assignment);
        //    await db.SaveChangesAsync();

        //    return Ok("Assignment added successfully");
        //}

        //[HttpGet("GetAssignments")]
        //public async Task<IActionResult> GetAssignments(string standard)
        //{
        //    var assignments = await db.assignments
        //        .Where(a => a.Standard == standard)
        //        .ToListAsync();

        //    return Ok(assignments);
        //}

        //[HttpPost("SubmitAssignment")]
        //public async Task<IActionResult> SubmitAssignment([FromBody] AssignmentSubmissionViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var submission = new AssignmentSubmission
        //    {
        //        AssignmentId = model.AssignmentId,
        //        StudentId = model.StudentId,
        //        SubmissionDate = DateTime.Now,
        //        FileUpload = model.FileUpload
        //    };

        //    db.assignmentSubmissions.Add(submission);
        //    await db.SaveChangesAsync();

        //    return Ok("Assignment submitted successfully");
        //}

        //[HttpGet("GetSubmissions/{assignmentId}")]
        //public async Task<IActionResult> GetSubmissions(int assignmentId)
        //{
        //    var submissions = await db.assignmentSubmissions
        //        .Where(s => s.AssignmentId == assignmentId)
        //        .ToListAsync();

        //    return Ok(submissions);
        //}


    }
}
