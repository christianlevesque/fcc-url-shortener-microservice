using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Webapp.Controllers;
using Webapp.Services;
using Xunit;

namespace Tests.Controllers
{
	public class UrlController_GetShortUrl
	{
		private const string Url = "https://www.christianlevesque.io/blog/fcc";
		
		[Fact]
		public void GetShortUrlReturnsNotFoundWhenIndexOutOfRange()
		{
			var validator = new Mock<IDomainValidatorService>();
			var controller = new UrlController(validator.Object);

			var result = controller.GetShortUrl(0);

			Assert.IsType<NotFoundResult>(result);
		}

		[Fact]
		public async Task GetShortUrlReturnsRedirectResultWhenShortUrlIsValid()
		{
			var validator = new Mock<IDomainValidatorService>();
			var controller = new UrlController(validator.Object);

			await controller.CreateShortUrl(Url);

			var result = controller.GetShortUrl(0);

			var response = Assert.IsType<RedirectResult>(result);
			Assert.Equal(Url, response.Url);
		}
	}
}