using Microsoft.EntityFrameworkCore;
using EBIM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EBIM.DB
{
	public class AppDb : IdentityDbContext<User, IdentityRole<int>, int>  // Configure Identity context with int as key
	{
		public AppDb(DbContextOptions<AppDb> options) : base(options) { }

		public DbSet<Apartment> Apartments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder); // Ensure Identity-related tables are configured correctly
		}
	}
}
