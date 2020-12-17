using Microsoft.AspNetCore.Mvc;

namespace Webapp.Controllers
{
	[ApiController]
	public class UrlController : ControllerBase
	{
		public IActionResult GetShortUrl()
		{
			return Ok();
		}
	}
}