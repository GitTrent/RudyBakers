using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data.Model
{
	public class OrderStatus
	{
		public int ID { get; set; }
		public DateTime ChangeDate { get; set; }
		public virtual OrderStatusEnum Status { get; set; }
	}
}
