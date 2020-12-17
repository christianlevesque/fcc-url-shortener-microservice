using System;
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
			// Mock setup
			var validator = new Mock<IDomainValidatorService>();
			var shortUrl = new Mock<IShortUrlService>();
			shortUrl.Setup(s => s.GetUrl(0))
					.Throws<IndexOutOfRangeException>();

			// Run tests
			var controller = new UrlController(validator.Object, shortUrl.Object);
			var result = controller.GetShortUrl(0);

			// Assertions
			Assert.IsType<NotFoundResult>(result);
		}

		[Fact]
		public async Task GetShortUrlReturnsRedirectResultWhenShortUrlIsValid()
		{
			// Mock setup
			var validator = new Mock<IDomainValidatorService>();
			var shortUrl = new Mock<IShortUrlService>();
			shortUrl.Setup(s => s.GetUrl(0))
					.Returns(Url);

			// Run tests
			var controller = new UrlController(validator.Object, shortUrl.Object);
			await controller.CreateShortUrl(Url);
			var result = controller.GetShortUrl(0);

			// Assertions
			var response = Assert.IsType<RedirectResult>(result);
			Assert.Equal(Url, response.Url);
		}
	}
}