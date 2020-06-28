
namespace API.AuthorizationInfo
{
	public class AuthInfo
	{
		public static string TwitterUsername { get; set; }
		public static string TwitterPassword { get; set; }

		public AuthInfo(string _twitterUsername, string _twitterPassword)
		{
			TwitterUsername = _twitterUsername;
			TwitterPassword = _twitterPassword;
		}
	}
}