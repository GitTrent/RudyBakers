using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data
{
	public interface IItem
	{
		string Name { get; set; }
		string ShortDescription { get; set; }
		string LongDescription { get; set; }
		Price Price { get; set; }
	}
}
