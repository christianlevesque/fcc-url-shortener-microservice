using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapp.Controllers;
using Xunit;

namespace Tests.Controllers
{
	public class UrlController_GetShortUrl
	{
		private const string Url = "https://www.christianlevesque.io/blog/fcc";
		
		[Fact]
		public void GetShortUrlReturnsNotFoundWhenIndexOutOfRange()
		{
			var controller = new UrlController();

			var result = controller.GetShortUrl(0);

			Assert.IsType<NotFoundResult>(result);
		}

		[Fact]
		public async Task GetShortUrlReturnsRedirectResultWhenShortUrlIsValid()
		{
			var controller = new UrlController();

			await controller.CreateShortUrl(Url);

			var result = controller.GetShortUrl(0);

			var response = Assert.IsType<RedirectResult>(result);
			Assert.Equal(Url, response.Url);
		}
	}
}