using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhosGotMyGames.Models;
using WhosGotMyGames.Models.Entities;

namespace WhosGotMyGames.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<WhosGotMyGames.Models.Entities.Game> Game { get; set; }

        public DbSet<WhosGotMyGames.Models.Entities.Friend> Friend { get; set; }

        public DbSet<WhosGotMyGames.Models.Entities.Lending> Lending { get; set; }
    }
}
