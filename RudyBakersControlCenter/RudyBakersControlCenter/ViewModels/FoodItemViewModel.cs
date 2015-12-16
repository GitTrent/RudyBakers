using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudyBakers.Data.Model;

namespace RudyBakersControlCenter.ViewModels
{
	public class FoodItemViewModel
	{
		public FoodItem FoodItem { get; set; }
		public ICollection<HealthInfo> AllHealthInfos { get; set; }
		public int[] PostedHealthInfoIds{ get; set; }
		
		public IEnumerable<string> PriceDisplay { get; set; }
	}
}

