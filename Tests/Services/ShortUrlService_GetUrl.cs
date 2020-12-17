using System;
using Webapp.Services;
using Xunit;

namespace Tests.Services
{
	public class ShortUrlService_GetUrl
	{
		private const string Url = "https://www.christianlevesque.io/blog/fcc";
		
		[Fact]
		public void GetUrlReturnsUrlWhenIndexValid()
		{
			// Run tests
			var shortUrl = new ShortUrlService();
			shortUrl.AddUrl(Url);
			var testUrl = shortUrl.GetUrl(0);
			
			// Assertions
			Assert.Equal(Url, testUrl);
		}

		[Fact]
		public void GetUrlThrowsWhenIndexInvalid()
		{
			var shortUrl = new ShortUrlService();

			Assert.Throws<ArgumentOutOfRangeException>(() => shortUrl.GetUrl(0));
		}
	}
}