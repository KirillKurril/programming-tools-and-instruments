using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MLWD5.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
