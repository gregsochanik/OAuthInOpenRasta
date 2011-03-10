using System;
using OpenRasta.Binding;

namespace OauthInOpenRasta.Handlers
{
	[Serializable]
	[KeyedValuesBinder]
	public class VoucherResource
	{
		public int Id { get; set; }
		public int DiscountValue { get; set; }
		public bool Redeemed { get; set; }
	}
}