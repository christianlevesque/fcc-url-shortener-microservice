using System;
using Webapp.Utilities;
using Xunit;

namespace Tests.Utilities
{
	public class DomainValidations_StripProtocol
	{
		private const string UrlWithHttp = "http://www.christianlevesque.io";
		private const string UrlWithHttps = "https://www.christianlevesque.io";
		private const string UrlWithoutHttp = "www.christianlevesque.io";

		[Fact]
		public void StripProtocolStripsProtocolWhenHttpPresent()
		{
			Assert.Equal(UrlWithoutHttp, DomainValidations.StripProtocol(UrlWithHttp));
		}

		[Fact]
		public void StripProtocolStripsProtocolWhenHttpsPresent()
		{
			Assert.Equal(UrlWithoutHttp, DomainValidations.StripProtocol(UrlWithHttps));
		}

		[Fact]
		public void StripProtocolStripsNothingWhenHttpNotPresent()
		{
			Assert.Equal(UrlWithoutHttp, DomainValidations.StripProtocol(UrlWithoutHttp));
		}

		[Fact]
		public void StripProtocolThrowsArgumentNullExceptionIfNull()
		{
			Assert.Throws<ArgumentNullException>(() => DomainValidations.StripProtocol(null));
		}
	}
}