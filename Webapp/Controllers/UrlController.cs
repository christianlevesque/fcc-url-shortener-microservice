using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Webapp.Controllers
{
	[ApiController]
	[Route("/shorturl")]
	public class UrlController : ControllerBase
	{
		private readonly IDictionary<string, string> _error = new Dictionary<string, string>
		{
			{"error", "invalid url"}
		};
		private readonly IList<string> _urls = new List<string>();
		
		[HttpGet("{index}")]
		public IActionResult GetShortUrl(int index)
		{
			if (_urls.Count <= index)
				return BadRequest(_error);

			return Ok();
		}
	}
}