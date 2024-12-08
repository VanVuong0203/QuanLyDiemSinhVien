using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using qlydiem.Models;

namespace qlydiem.Data
{
    public class qlydiemContext : DbContext
    {
        public qlydiemContext (DbContextOptions<qlydiemContext> options)
            : base(options)
        {
        }

        public DbSet<qlydiem.Models.Diem> Diem { get; set; } = default!;
    }
}
