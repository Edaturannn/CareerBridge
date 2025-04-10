using System;
using Microsoft.EntityFrameworkCore;
using Website.Entities.Concrete;

namespace Website.DataAccess.Concrete
{
	public class Context : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost,5432;Database=KariyerWebDatabase2;Username=;Password=;TrustServerCertificate=True;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Departmant> Departmants { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
    }
}

