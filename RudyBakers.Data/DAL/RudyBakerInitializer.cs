using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudyBakers.Data.Model;

namespace RudyBakers.Data.DAL
{
	public class RudyBakerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RudyBakerContext>
	{
		protected override void Seed(RudyBakerContext context)
		{
			var healthInfos = new Collection<HealthInfo>
			{
				new HealthInfo {ID = 1, Info = "Contains Nuts"},
				new HealthInfo {ID = 2, Info = "Gluten Free"},
				new HealthInfo {ID = 3, Info = "Fat Free"}
			};
			context.HealthInfos.AddRange(healthInfos);
			context.SaveChanges();

			var prices = new Collection<Price>
			{
				new Price {ID = 1, Amount = 2, Unit = UnitEnum.Each},
				new Price {ID = 2, Amount = 18, Unit = UnitEnum.Dozen},
				new Price {ID = 3, Amount = 5, Unit = UnitEnum.Each},
				new Price {ID = 4, Amount = 50, Unit = UnitEnum.Dozen},
                new Price {ID = 5, Amount = 25, Unit = UnitEnum.Each},
                new Price {ID = 6, Amount = 10, Unit = UnitEnum.Each}
			};
			context.Prices.AddRange(prices);
			context.SaveChanges();

			var foodItems = new List<FoodItem>()
			{
				new FoodItem {ID = 1, Name = "Chocolate Cupcake", ShortDescription = "Delecious Chocolate Cupcake", LongDescription = "Chocolate cupcase made from the finest ingeredients.", Prices = prices.Where(p => p.ID == 1 || p.ID == 2).ToList()},
				new FoodItem {ID = 2, Name = "Vanilla Cupcake", ShortDescription = "Delecious Vanilla Cupcake", LongDescription = "Vanilla cupcase made from the finest ingeredients.", Prices = prices.Where(p => p.ID == 3 || p.ID == 4).ToList()},
				new FoodItem {ID = 2, Name = "Gluten Free Chocolate Cupcake", ShortDescription = "Delecious Chocolate Cupcake", LongDescription = "Our famous chocolate cupcake made with gluten free flour.", Prices = prices.Where(p => p.ID == 3 || p.ID == 4).ToList(), HealthInfos = healthInfos.Where(hi => hi.ID == 2).ToList()},
			};
			var items = new List<Item>()
			{
				new Item {ID = 3, Name = "Cupcake Pan", ShortDescription = "Cupcake Pan for 12 cupcakes", LongDescription = "Use this pan to cook a dozen cupcakes.", Prices = prices.Where(p=>p.ID == 5).ToList()},
				new Item {ID = 4, Name = "Icing Spatula", ShortDescription = "Gourmet Icing Spatula", LongDescription = "Spatula perfect for icing cakes or cupcakes.", Prices = prices.Where(p=>p.ID == 6).ToList()},
			};
			context.Items.AddRange(items);
			context.FoodItems.AddRange(foodItems);
			context.SaveChanges();
		}
	}
}
