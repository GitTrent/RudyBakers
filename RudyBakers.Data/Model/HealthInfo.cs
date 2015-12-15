using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data.Model
{
	public class HealthInfo
	{
		public int ID { get; set; }
		public string Info { get; set; }

		public virtual ICollection<FoodItem> FoodItems { get; set; }
	}
}
