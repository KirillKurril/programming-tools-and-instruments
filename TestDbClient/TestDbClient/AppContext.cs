using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Models;

namespace TestDbClient
{
    public class AppContext : DbContext
    {
        public DbSet<Cell> Cells {  get; set; }
        public DbSet<GameBoard> GameBoards { get; set; }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<MainFan> MainFans { get; set; }
        string dbName = "test.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={dbName}");
        }
    }
}
