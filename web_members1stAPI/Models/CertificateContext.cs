using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_members1stAPI.Models
{
    public class CertificateContext: DbContext
    {
        public CertificateContext(DbContextOptions<CertificateContext> options) : base(options)
        {
        }
        public DbSet<Certificate> certificates { get; set; }

    }
}
