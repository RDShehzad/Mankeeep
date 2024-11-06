using Mankeep.Models;
using Mankeep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Mankeep
{
	public class ApplicationDbContext : DbContext
	{
		private readonly IConfiguration _configuration;
	    public DateTime created_at;
		public DateTime updated_at;
		public DateTime deleted_at;
		

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options) {
			_configuration = configuration;
			
		}	

		// Define DbSet properties for your entities, e.g.:
		public DbSet<User> users { get; set; }
		public DbSet<expense_category> expense_category { get; set; }
		public DbSet<expenses> expenses { get; set; }
		public DbSet<supplier> suppliers { get; set; }
		public DbSet<customers> customers { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<expenses>()
				.HasOne(e => e.expense_category)
				.WithMany(ec => ec.expenses)
				.HasForeignKey(e => e.expense_category_id);

			// Additional configuration if needed
			base.OnModelCreating(modelBuilder);

			// Apply a global filter to exclude soft-deleted records
			//modelBuilder.Entity<supplier>().HasQueryFilter(e => !e.deleted_at.HasValue);
		}


		

	








	}
}
