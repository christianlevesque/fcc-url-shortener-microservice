using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Webapp.Models;

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

		[HttpPost("new")]
		public IActionResult CreateShortUrl([FromForm] string url)
		{
			_urls.Add(url);
			var newPosition = _urls.Count - 1;

			return Created($"/shorturl/{newPosition}", new ShortUrl
			{
				ShortenedUrl = newPosition,
				OriginalUrl = url
			});
		}
	}
}