using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data.Model
{
	public class Item : IItem
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public virtual ICollection<Price> Prices { get; set; }
	}
}
