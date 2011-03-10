using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using OauthInOpenRasta.Handlers;
using OpenRasta.Configuration;
using OpenRasta.Pipeline;
using OpenRasta.Pipeline.Contributors;
using OpenRasta.Web;

namespace OauthInOpenRasta
{
	public class ConfigurationSource : IConfigurationSource
	{
		public void Configure()
		{
			ResourceSpace.Has
					.ResourcesOfType<VoucherResource>()
					.AtUri("/voucher/{Id}")
					.HandledBy<VoucherHandler>()
					.AsXmlSerializer()
					.ForMediaType(new MediaType("text/xml")).ForMediaType(MediaType.Xml);

			ResourceSpace.Has
				.ResourcesOfType<VoucherResource>()
				.AtUri("/accessToken/{voucherId}")
				.HandledBy<AccessTokenHandler>()
				.AsXmlSerializer()
				.ForMediaType(MediaType.MultipartFormData).ForMediaType(MediaType.Xml);

			//RemoveDigestAuthorisationContributor(DependencyResolver.Container);
		}

		/// <summary>
		/// http://trac.caffeine-it.com/openrasta/ticket/118#comment:1
		/// See OpenRasta.DigestAuthorizerContributor.WriteCredentialRequest
		/// TODO: Need to implement 
		/// </summary>
		public static void RemoveDigestAuthorisationContributor(IWindsorContainer container)
		{
			var contributors = container.Kernel.GetHandlers(typeof(IPipelineContributor));
			var digestContributor = contributors.SingleOrDefault(i => i.ComponentModel.Implementation == typeof(DigestAuthorizerContributor));

			container.Kernel.RemoveComponent(digestContributor.ComponentModel.Name);
		}
	}
}