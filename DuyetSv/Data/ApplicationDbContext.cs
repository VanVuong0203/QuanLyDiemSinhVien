using DuyetSv.Models;
using Microsoft.EntityFrameworkCore;

namespace DuyetSv.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<SinhVien> SinhViens { get; set; }
        public object sinhviens { get; internal set; }
    }
}
