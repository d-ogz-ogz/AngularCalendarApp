
using Microsoft.EntityFrameworkCore;
using SHARED.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Db
{
    public class CalendarAppDbContext : DbContext
    {
        public DbSet<NoteDto> notes { get; set; }
     


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CalendarApp;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}