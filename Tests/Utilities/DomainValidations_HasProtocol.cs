using System;
using Webapp.Utilities;
using Xunit;

namespace Tests.Utilities
{
	public class DomainValidations_HasProtocol
	{
		private const string UrlWithHttp = "http://www.christianlevesque.io";
		private const string UrlWithHttps = "https://www.christianlevesque.io";
		private const string UrlWithoutHttp = "www.christianlevesque.io";
		
		[Fact]
		public void HasProtocolReturnsFalseIfNoHttp()
		{
			Assert.False(DomainValidations.HasProtocol(UrlWithoutHttp));
		}

		[Fact]
		public void HasProtocolReturnsTrueIfHttp()
		{
			Assert.True(DomainValidations.HasProtocol(UrlWithHttp));
		}

		[Fact]
		public void HasProtocolReturnsTrueIfHttps()
		{
			Assert.True(DomainValidations.HasProtocol(UrlWithHttps));
		}

		[Fact]
		public void HasProtocolThrowsArgumentNullExceptionIfNull()
		{
			Assert.Throws<ArgumentNullException>(() => DomainValidations.HasProtocol(null));
		}
	}
}