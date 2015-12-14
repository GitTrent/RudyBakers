using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudyBakers.Data.Enums;

namespace RudyBakers.Data
{
	public class OrderStatus
	{
		public DateTime ChangeDate { get; set; }
		public OrderStatusEnum Status { get; set; }
	}
}
