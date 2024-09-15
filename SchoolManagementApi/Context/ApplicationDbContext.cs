using Microsoft.EntityFrameworkCore;
using SchoolManagement.Model;
using SchoolManagementApi.Model;
using System.Collections.Generic;

namespace SchoolManagementApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StudentRequest> studentRequests { get; set; }

        public DbSet<AddStudent> Student { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<AddTeacher> Teachers { get; set; }
        public DbSet<AddLibrarian> Librarian { get; set; }
        public DbSet<TeacherLeaveRequest> TeacherLeaves { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Assignments> assignments { get; set; }
        public DbSet<AssignmentSubmission> assignmentSubmissions { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

    }
}
