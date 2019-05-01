using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_members1stAPI.Models
{
    public class LoanContext: DbContext
    {
        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {
        }
        public DbSet<Loan> loans { get; set; }

    }
}
