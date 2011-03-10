using OauthInOpenRasta.Handlers;
using OpenRasta.Authentication;

namespace OauthInOpenRasta.Authentication
{
	public class OAuthSuccess : AuthenticationResult
	{
		public OAuthSuccess()
		{ }

		public OAuthSuccess(OAuthCredentials credentials)
		{
			Credentials = credentials;
		}

		public OAuthCredentials Credentials { get; set; }
	}
}