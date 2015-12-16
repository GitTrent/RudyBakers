using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RudyBakers.Data
{
	public class Connection
	{
		private Connection()
		{
		}

		private static Connection _connection;
		private string _string;



		public static string ConnectString
		{
			get
			{
				if (_connection == null)
				{
					_connection = new Connection {_string = Connection.Connect};
				}
			}
		}
		public static string Connect()
		{
			var connectData = JsonConvert.DeserializeObject<Dictionary<string, string>>();
			var connect = new SqlConnectionStringBuilder
			{
				DataSource = connectData["server"],
				InitialCatalog = ConnectString["database"],
				UserID = connectData["username"],
				Password = connectData["password"]
			};
			var entityString = new EntityConnectionStringBuilder
			{
				Provider = connectData["provider"],
			}
			
		}
	}
}
