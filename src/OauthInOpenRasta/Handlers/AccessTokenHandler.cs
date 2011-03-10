using OauthInOpenRasta.Authentication;
using OpenRasta.Web;

namespace OauthInOpenRasta.Handlers
{
	public class AccessTokenHandler
	{
		private readonly ICommunicationContext _context;

		public AccessTokenHandler(ICommunicationContext context)
		{
			_context = context;
		}

		[RequiresOAuth]
		public OperationResult Post(int voucherId)
		{
			// find a way of getting back the AuthorisationResult
			var result = _context.OperationResult;

			return new OperationResult.OK { ResponseResource = new OAuthCredentials("99fe97e1", "255ae587", true) };
		}
	}
}