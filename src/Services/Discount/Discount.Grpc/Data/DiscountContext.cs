using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
	public class DiscountContext : DbContext
	{
		public DiscountContext(DbContextOptions<DiscountContext> options) 
			: base(options)
		{
		}

		public DbSet<Coupon> Coupons { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Coupon>().HasData(
				new Coupon { Id = 1, ProductName = "Gaming PC - RTX 4080", Description = "High-performance gaming PC with RTX 4080 graphics card and 32GB RAM.", Amount = 150},
				new Coupon { Id = 2, ProductName = "Wireless Gaming Mouse", Description = "Ergonomic wireless mouse with customizable RGB lighting.", Amount = 200 }
				);
			base.OnModelCreating(modelBuilder);
		}
	}
}
