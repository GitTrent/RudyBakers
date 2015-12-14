using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudyBakers.Data.Enums;

namespace RudyBakers.Data
{
	public class Order
	{
		public DateTime OrderDate { get; set; }
		public User Customer { get; set; }
		public List<IItem> Items { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		public Address ShipToAddress { get; set; }
		public List<OrderStatus> OrderStatus { get; set; }
	}
}
