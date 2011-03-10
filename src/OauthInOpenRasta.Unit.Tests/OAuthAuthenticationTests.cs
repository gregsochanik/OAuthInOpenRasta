using NUnit.Framework;
using OauthInOpenRasta.Authentication;
using OpenRasta.Web;
using Rhino.Mocks;

namespace OauthInOpenRasta.Unit.Tests
{
	[TestFixture]
	public class OAuthAuthenticationTests
	{
		private const string OAUTH_HEADER = @"OAuth realm='http://localhost/restful_service/download', 
												oauth_consumer_key=light, 
												oauth_token='TOKEN', 
												oauth_nonce='nonce', 
												oauth_timestamp='TIMESTAMP', 
												oauth_signature_method='HMAC-SHA1', 
												oauth_version='1.0', 
												oauth_signature='SIGNATURE'";

		[Test]
		public void Should_fire_header_mapper_with_correct_value()
		{
			var headerMapper = MockRepository.GenerateStub<IHeaderMapper<OAuthRequestHeader>>();
			var request = MockRepository.GenerateStub<IRequest>();
			var context = MockRepository.GenerateStub<ICommunicationContext>();
			request.Stub(x => x.Headers).Return(new HttpHeaderDictionary() { { "Authorization", OAUTH_HEADER } });
			headerMapper.Stub(x => x.Map(OAUTH_HEADER)).Return(new OAuthRequestHeader(){ConsumerKey = "light"});
			var oAuthAuthenticationScheme = new OAuthAuthenticationScheme(headerMapper, context);
			oAuthAuthenticationScheme.Authenticate(request);
			headerMapper.AssertWasCalled(x => x.Map(OAUTH_HEADER));
		}
	}
}