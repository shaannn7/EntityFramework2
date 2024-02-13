using EntityFramework2.Entity;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework2.Data
{
    public class DbContextClass : DbContext
    {
        private readonly IConfiguration _configuration;
        public string CString;
        public DbContextClass(IConfiguration configuration)
        {
            _configuration = configuration;
            CString = _configuration["ConnectionStrings:DefaultConnection"];
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CString);
        }
        public DbSet<Students> Student { get; set; }
        public DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
                .HasOne(i => i.Course)
                .WithMany(i => i.Student_d)
                .HasForeignKey(i => i.CourseId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
