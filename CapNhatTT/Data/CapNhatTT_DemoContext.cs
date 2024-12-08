using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapNhatTT_Demo.Models;

namespace CapNhatTT_Demo.Data
{
    public class CapNhatTT_DemoContext : DbContext
    {
        public CapNhatTT_DemoContext (DbContextOptions<CapNhatTT_DemoContext> options)
            : base(options)
        {
        }

        public DbSet<CapNhatTT_Demo.Models.ThongTinSVModel> ThongTinSVModel { get; set; } = default!;
    }
}
