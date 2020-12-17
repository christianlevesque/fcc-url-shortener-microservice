using Microsoft.AspNetCore.Mvc;
using Webapp.Controllers;
using Webapp.Models;
using Xunit;

namespace Tests.Controllers
{
	public class UrlController_CreateShortUrl
	{
		private const string Url = "https://www.christianlevesque.io";

		[Fact]
		public void CreateShortUrlReturnsCreatedResult()
		{
			var controller = new UrlController();

			var result = controller.CreateShortUrl(Url);

			var response = Assert.IsType<CreatedResult>(result);
			Assert.NotNull(response.Value);
			Assert.IsType<ShortUrl>(response.Value);
			Assert.Equal(Url, (response.Value as ShortUrl)?.OriginalUrl);
			Assert.Equal(0, ((ShortUrl) response.Value).ShortenedUrl);
		}
	}
}