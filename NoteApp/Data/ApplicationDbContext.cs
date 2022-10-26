using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteApp.Data.Entities;

namespace NoteApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Roles,int>
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<IdentityUser>();

            builder.Entity<Note>(b =>
            {
                b.HasOne(x => x.Users).WithMany(x=>x.Notes).HasForeignKey(x=>x.UserId);
            });

            builder.Entity<User>(b =>
            {
                b.ToTable("Users");
                b.Property(x => x.Id).HasMaxLength(36);
            });

        }

    }
}
