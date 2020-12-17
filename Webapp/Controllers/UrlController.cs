using Microsoft.AspNetCore.Mvc;

namespace Webapp.Controllers
{
	[ApiController]
	[Route("/shorturl")]
	public class UrlController : ControllerBase
	{
		[HttpGet("{index}")]
		public IActionResult GetShortUrl(int index)
		{
			return Ok();
		}
	}
}