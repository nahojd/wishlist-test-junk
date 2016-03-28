using System.Data.Common;

namespace Wishlist.Model
{
	public interface IDbConnectionFactory
	{
		DbConnection OpenConnection();
	}
}