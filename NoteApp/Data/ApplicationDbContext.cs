using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteApp.Data.Entities;

namespace NoteApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Note>(b =>
            {
                b.HasOne(x => x.Users).WithMany(x=>x.Notes).HasForeignKey(x=>x.UserId);
            });


        }
    }
}
