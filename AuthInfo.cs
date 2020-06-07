using System;

public class AuthInfo
{
	public string TwitterUsername { get; set; }
	public string TwitterPassword { get; set; }

	public AuthInfo(string _twitterUsername, string _twitterPassword)
	{
		TwitterUsername = _twitterUsername;
		TwitterPassword = _twitterPassword;
	}
}
