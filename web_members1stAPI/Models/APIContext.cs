using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace web_members1stAPI.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base (options)
            {
            }
        public DbSet<Profile> Profiles { get; set; }

    }
}
