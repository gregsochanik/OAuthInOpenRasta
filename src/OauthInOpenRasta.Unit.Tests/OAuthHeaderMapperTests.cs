using NUnit.Framework;
using OauthInOpenRasta.Authentication;

namespace OauthInOpenRasta.Unit.Tests
{
	[TestFixture]
	public class OAuthHeaderMapperTests
	{
		private const string OAUTH_HEADER = @"OAuth realm='http://localhost/restful_service/download', 
												oauth_consumer_key=YOUR_KEY_HERE, 
												oauth_token=TOKEN, 
												oauth_nonce=nonce, 
												oauth_timestamp=TIMESTAMP, 
												oauth_signature_method=HMAC-SHA1, 
												oauth_version=1.0, 
												oauth_signature=SIGNATURE";

		[Test]
		public void Should_map_fields_correctly()
		{
			OAuthRequestHeader oAuthRequestHeader = new OAuthHeaderMapper().Map(OAUTH_HEADER);
			Assert.That(oAuthRequestHeader.ConsumerKey, Is.EqualTo("YOUR_KEY_HERE"));
			Assert.That(oAuthRequestHeader.Token, Is.EqualTo("TOKEN"));
			Assert.That(oAuthRequestHeader.Nonce, Is.EqualTo("nonce"));
			Assert.That(oAuthRequestHeader.Timestamp, Is.EqualTo("TIMESTAMP"));
			Assert.That(oAuthRequestHeader.SignatureMethod, Is.EqualTo("HMAC-SHA1"));
			Assert.That(oAuthRequestHeader.Version, Is.EqualTo("1.0"));
			Assert.That(oAuthRequestHeader.Signature, Is.EqualTo("SIGNATURE"));
		}
	}
}