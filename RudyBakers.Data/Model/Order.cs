using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data.Model
{
	public class Order
	{
		public int ID { get; set; }
		public DateTime OrderDate { get; set; }
		public virtual User Customer { get; set; }
		public virtual List<IItem> Items { get; set; }
		public virtual PaymentMethod PaymentMethod { get; set; }
		public virtual Address ShipToAddress { get; set; }
		public virtual List<OrderStatus> OrderStatus { get; set; }
	}
}
