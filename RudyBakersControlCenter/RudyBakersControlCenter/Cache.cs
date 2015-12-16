using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using RudyBakers.Data.DAL;
using RudyBakers.Data.Model;

namespace RudyBakersControlCenter
{
	public class CacheManager
	{
		public static ICollection<HealthInfo> GetHealthInfos()
		{
			var hi = WebCache.Get(Constants.AS_HealthInfos);
			if (hi != null) return hi;
			using (var ctx = new RudyBakerContext())
			{
				ctx.HealthInfos.Load();
				WebCache.Set(Constants.AS_HealthInfos, ctx.HealthInfos.ToList()	, 30, false);
				return ctx.HealthInfos.ToList();
			}
		}
	}
}
