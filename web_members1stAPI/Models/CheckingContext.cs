using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_members1stAPI.Models
{
    public class CheckingContext : DbContext
    {
        public CheckingContext(DbContextOptions<CheckingContext> options) : base(options)
        {
        }
        public DbSet<Checking> checking { get; set; }

    }
}
