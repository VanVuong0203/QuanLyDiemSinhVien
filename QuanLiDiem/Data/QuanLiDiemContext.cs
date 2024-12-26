using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuanLiDiem.Data
{
    public class QuanLiDiemContext : DbContext
    {
        public QuanLiDiemContext (DbContextOptions<QuanLiDiemContext> options)
            : base(options)
        {
        }

        public DbSet<Diem> Diem { get; set; } = default!;
    }
}
