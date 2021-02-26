using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BMSDemoAPI.Models
{
    public class BMSDemoAPIDBContext : DbContext
    {
        public BMSDemoAPIDBContext(DbContextOptions<BMSDemoAPIDBContext> options) :base(options)
        {

        }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasKey(u => new { u.UserName, u.UserPassword });
        }
    }
}
