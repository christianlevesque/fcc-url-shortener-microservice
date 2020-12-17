using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapp.Models;
using Webapp.Services;
using Webapp.Utilities;

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
		private readonly IDomainValidatorService _validator;

		public UrlController(IDomainValidatorService validator)
		{
			_validator = validator;
		}

		[HttpGet("{id}")]
		public IActionResult GetShortUrl(int id)
		{
			if (_urls.Count <= id)
				return NotFound();

			return RedirectPermanent(_urls[id]);
		}

		[HttpPost("new")]
		public async Task<IActionResult> CreateShortUrl([FromForm] string url)
		{
			if (!await _validator.IsValidDomain(url))
				return BadRequest(_error);

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