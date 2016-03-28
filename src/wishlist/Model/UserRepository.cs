using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dapper;

namespace Wishlist.Model {
	
	public interface IUserRepository 
	{
		IReadOnlyList<string> GetAllUsers();
		IReadOnlyList<string> GetFriends(string username);
		
		bool AuthenticateUser(string username, string password);
	}
	
	public class UserRepository : IUserRepository 
	{
		private readonly IDbConnectionFactory connectionFactory;
	
		public UserRepository(IDbConnectionFactory connectionFactory) {
			this.connectionFactory = connectionFactory;
		}
		
	
		public IReadOnlyList<string> GetFriends(string username) {
			
			using (var conn = connectionFactory.OpenConnection()) 
			{				
				var users = conn.Query<string>("select name from users where id in (select friendId from friends inner join users on friends.userId = users.id where name = @username)", new { username });				
				return users.ToList().AsReadOnly();
			}
			
		}  
		
		public IReadOnlyList<string> GetAllUsers() {
			 using (var conn = connectionFactory.OpenConnection()) 
			 {			
				var users = conn.Query<string>("select name from users");				
				return users.ToList().AsReadOnly();
			}
		} 
		
		public bool AuthenticateUser(string username, string password) {
			//We don't even have passwords yet, so let's just authenticate all users that exist in the database!
			
			using (var conn = connectionFactory.OpenConnection())
			{
				var matchingUser = conn.Query<dynamic>("select * from users where name = @username", new { username }).SingleOrDefault();
				Console.WriteLine($"Matching user: {matchingUser?.name ?? "none"}");
				return matchingUser != null;

			}
		}
	}
	
}