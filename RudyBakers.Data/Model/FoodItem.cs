using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data.Model
{
	public class FoodItem : IItem
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public virtual ICollection<Price> Prices { get; set; }
		public virtual ICollection<HealthInfo> HealthInfos { get; set; }

		public FoodItem()
		{
			this.Prices = new HashSet<Price>();
			this.HealthInfos = new HashSet<HealthInfo>();
		}
	
}
}
