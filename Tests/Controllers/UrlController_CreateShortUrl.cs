using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Webapp.Controllers;
using Webapp.Models;
using Webapp.Services;
using Xunit;

namespace Tests.Controllers
{
	public class UrlController_CreateShortUrl
	{
		private const string Url = "https://www.christianlevesque.io";
		private const string InvalidUrl = "christian levesque dot io";

		[Fact]
		public async Task CreateShortUrlReturnsCreatedResult()
		{
			var validator = new Mock<IDomainValidatorService>();
			validator.Setup(v => v.IsValidDomain(Url))
					 .ReturnsAsync(true);
			var controller = new UrlController(validator.Object);

			var result = await controller.CreateShortUrl(Url);

			var response = Assert.IsType<CreatedResult>(result);
			Assert.NotNull(response.Value);
			Assert.IsType<ShortUrl>(response.Value);
			Assert.Equal(Url, (response.Value as ShortUrl)?.OriginalUrl);
			Assert.Equal(0, ((ShortUrl) response.Value).ShortenedUrl);
		}

		[Fact]
		public async Task CreateShortUrlReturnsBadRequestResultIfUrlInvalid()
		{
			var validator = new Mock<IDomainValidatorService>();
			validator.Setup(v => v.IsValidDomain(InvalidUrl))
					 .ReturnsAsync(false);
			var controller = new UrlController(validator.Object);
		
			var result = await controller.CreateShortUrl(InvalidUrl);
		
			var response = Assert.IsType<BadRequestObjectResult>(result);
			Assert.NotNull(response.Value);
			Assert.IsType<Dictionary<string, string>>(response.Value);
			Assert.Equal(1, (response.Value as IDictionary<string, string>)?.Keys.Count);
			Assert.True((response.Value as IDictionary<string, string>)?.ContainsKey("error"));
			Assert.Equal("invalid url", (response.Value as IDictionary<string, string>)?["error"]);
		}
	}
}