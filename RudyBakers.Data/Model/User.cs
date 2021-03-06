﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data.Model
{
    public class User
    {
		public int ID { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public virtual IDictionary<string, Address> Addresses { get; set; }
		public virtual IDictionary<string, PaymentMethod> PaymentMethods { get; set; }
    }
}
