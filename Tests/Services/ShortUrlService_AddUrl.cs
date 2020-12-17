using Webapp.Models;
using Webapp.Services;
using Xunit;

namespace Tests.Services
{
	public class ShortUrlService_AddUrl
	{
		private const string Url1 = "https://www.christianlevesque.io/blog/fcc";
		private const string Url2 = "https://www.christianlevesque.io/blog/fullstack/html-css";

		[Fact]
		public void AddUrlAddsNewUrl()
		{
			// Run tests
			var shortUrl = new ShortUrlService();
			
			// Assertions
			Assert.Equal(0, shortUrl.Urls.Count);
			
			// More tests
			shortUrl.AddUrl(Url1);

			// More assertions
			Assert.Equal(1, shortUrl.Urls.Count);
			Assert.Contains(Url1, shortUrl.Urls);

			// More tests
			shortUrl.AddUrl(Url2);

			// More assertions
			Assert.Equal(2, shortUrl.Urls.Count);
			Assert.Contains(Url2, shortUrl.Urls);
		}

		[Fact]
		public void AddUrlReturnsShortUrl()
		{
			// Run tests
			var shortUrl = new ShortUrlService();
			var shortUrl1 = shortUrl.AddUrl(Url1);
			var shortUrl2 = shortUrl.AddUrl(Url2);

			// Assertions
			Assert.IsType<ShortUrl>(shortUrl1);
			Assert.IsType<ShortUrl>(shortUrl2);
			Assert.Equal(Url1, shortUrl1.OriginalUrl);
			Assert.Equal(Url2, shortUrl2.OriginalUrl);
			Assert.Equal(0, shortUrl1.ShortenedUrl);
			Assert.Equal(1, shortUrl2.ShortenedUrl);
		}
	}
}