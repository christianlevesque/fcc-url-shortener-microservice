using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webapp.Controllers;
using Xunit;

namespace Tests.Controllers
{
	public class UrlController_GetShortUrl
	{
		[Fact]
		public void GetShortUrlReturnsBadRequestWhenIndexOutOfRange()
		{
			var controller = new UrlController();

			var result = controller.GetShortUrl(0);

			var response = Assert.IsType<BadRequestObjectResult>(result);
			Assert.NotNull(response.Value);
			Assert.IsType<Dictionary<string, string>>(response.Value);
			Assert.Equal(1, (response.Value as IDictionary<string, string>)?.Keys.Count);
			Assert.True((response.Value as IDictionary<string, string>)?.ContainsKey("error"));
			Assert.Equal("invalid url", (response.Value as IDictionary<string, string>)?["error"]);
		}
	}
}