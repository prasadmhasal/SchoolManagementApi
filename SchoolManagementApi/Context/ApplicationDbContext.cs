using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Model;
using System.Collections.Generic;

namespace SchoolManagementApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StudentRequest> studentRequests { get; set; }
    }
}
