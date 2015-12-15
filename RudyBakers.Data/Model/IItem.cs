using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data.Model
{
	public interface IItem
	{
		int ID { get; set; }
		string Name { get; set; }
		string ShortDescription { get; set; }
		string LongDescription { get; set; }
		ICollection<Price> Prices { get; set; }
	}
}
