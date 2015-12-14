using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudyBakers.Data.Enums;

namespace RudyBakers.Data
{
	public class Price
	{
		public decimal Amount { get; set; }
		public UnitEnum Unit { get; set; }
	}
}
