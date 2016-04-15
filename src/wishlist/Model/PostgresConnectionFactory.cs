using System;
using System.Data.Common;
using Npgsql;

namespace Wishlist.Model
{
	public class PostgresConnectionFactory : IDbConnectionFactory
	{
		//TODO: Move to config
		private const string ConnectionString = "Host=192.168.99.100;Username=postgres;Password=wishlist;Database=wishlist;";
		
		public DbConnection OpenConnection() {
			var conn = new NpgsqlConnection(ConnectionString);
			conn.Open();
			return conn;
		}
	}
}