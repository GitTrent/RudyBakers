using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudyBakers.Data.Model;

namespace RudyBakers.Data.DAL
{
	public class RudyBakerContext : DbContext
	{
		public RudyBakerContext() : base("RudyBakerContext")
		{
		}
		

		public DbSet<Address> Addresses { get; set; }
		public DbSet<FoodItem> FoodItems { get; set; }
		public DbSet<HealthInfo> HealthInfos { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderStatus> OrderStatuses { get; set; }
		public DbSet<PaymentMethod> PaymentMethods{ get; set; }
		public DbSet<Price> Prices { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Entity<FoodItem>()
				.HasMany(f=>f.HealthInfos)
				.WithMany(h=>h.FoodItems)
				.Map(m =>
				{
					m.ToTable("FoodItemHealthInfo");
					m.MapLeftKey("FoodItem_ID");
					m.MapRightKey("HealthInfo_ID");
				}
				);
			base.OnModelCreating(modelBuilder);
			
			
		}
		protected override void OnConfiguring(Entityop)
	}
	
}
