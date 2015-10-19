using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data
{
	class PaymentMethod
	{
		public string Number { get; set; }
		public string ExpireDate { get; set; }
		public string CVV { get; set; }
		public Address Address { get; set; }
	}
}
