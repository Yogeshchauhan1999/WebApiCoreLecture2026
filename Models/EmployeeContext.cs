using Microsoft.EntityFrameworkCore;

namespace WebApiCoreLecture.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {
            
        }

        public DbSet<TblEmployee> TblEmployees { get; set; }
        public DbSet<TblDesignation> TblDesignation { get; set; }
    }
}
