using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudyBakers.Data.Enums
{
	public enum UnitEnum
	{
		Each,
		Pound,
		Dozen
	}

	public enum OrderStatusEnum
	{
		New,
		PendingPayment,
		BeingProcessed,
		ReadyToShip,
		Shipped,
		Complete
	}
}
