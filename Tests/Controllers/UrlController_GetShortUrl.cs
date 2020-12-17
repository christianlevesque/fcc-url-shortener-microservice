using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webapp.Controllers;
using Xunit;

namespace Tests.Controllers
{
	public class UrlController_GetShortUrl
	{
		[Fact]
		public void GetShortUrlReturnsNotFoundWhenIndexOutOfRange()
		{
			var controller = new UrlController();

			var result = controller.GetShortUrl(0);

			Assert.IsType<NotFoundResult>(result);
		}
	}
}