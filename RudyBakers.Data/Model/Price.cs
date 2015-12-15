using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data.Model
{
	public class Price
	{
		public int ID { get; set; }
		public decimal Amount { get; set; }
		public UnitEnum Unit { get; set; }
	}
}
