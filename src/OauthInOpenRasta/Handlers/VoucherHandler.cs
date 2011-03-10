using OauthInOpenRasta.Authentication;
using OpenRasta.Web;

namespace OauthInOpenRasta.Handlers
{
	public class VoucherHandler
	{
		public OperationResult Get(VoucherResource voucher)
		{
			return new OperationResult.OK { ResponseResource = new VoucherResource { DiscountValue = 10, Id = voucher.Id, Redeemed = false } };
		}

		[RequiresOAuth]
		public OperationResult Delete(VoucherResource voucher)
		{

			return new OperationResult.OK();
		}
	}
}