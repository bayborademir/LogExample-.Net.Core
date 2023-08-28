using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using qwerty.Enttities;

namespace qwerty.DataAcces
{
	public class FootballerDbContext : IdentityDbContext<AppUser,AppRole,int>
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FootballerDb;uid=SA;pwd=reallyStrongPwd123;TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }

    }

}

