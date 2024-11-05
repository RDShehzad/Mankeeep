using Mankeep.Models;
using Mankeep.Models;
using Microsoft.EntityFrameworkCore;

namespace Mankeep
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		// Define DbSet properties for your entities, e.g.:
		public DbSet<User> users { get; set; }
		public DbSet<expense_category> expense_category { get; set; }
		public DbSet<expenses> expenses { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<expenses>()
				.HasOne(e => e.expense_category)
				.WithMany(ec => ec.expenses)
				.HasForeignKey(e => e.expense_category_id);

			// Additional configuration if needed
		}

		public DbSet<supplier> suppliers { get; set; }
	}
}
