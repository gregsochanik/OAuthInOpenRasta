namespace OauthInOpenRasta.Handlers
{
	public class OAuthCredentials
	{
		public string Token { get; set; }
		public string TokenSecret { get; set; }
		public bool CallbackConfirmed { get; set; }

		public OAuthCredentials(string token, string tokensecret, bool callbackConfirmed)
		{
			Token = token;
			TokenSecret = tokensecret;
			CallbackConfirmed = callbackConfirmed;
		}
	}
}