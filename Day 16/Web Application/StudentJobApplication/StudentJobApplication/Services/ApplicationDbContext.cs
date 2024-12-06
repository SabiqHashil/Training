
using Microsoft.EntityFrameworkCore;
using StudentJobApplication.Models;

namespace StudentJobApplication.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
