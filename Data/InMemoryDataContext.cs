using BasicCRM.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicCRM.Api.Data
{
	public class InMemoryDataContext : DbContext
	{
		public InMemoryDataContext(DbContextOptions<InMemoryDataContext> options) : base(options)
		{
			this.Database.EnsureCreated();
		}

		public DbSet<CustomerEntity> Customers { get; set; }
		public DbSet<ProductEntity> Products { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Customer>()
		//		.HasMany(c => c.Products)
		//}
	}
}
