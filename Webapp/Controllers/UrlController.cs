using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webapp.Services;

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

		private readonly IDomainValidatorService _validator;
		private readonly IShortUrlService _shortUrl;

		public UrlController(IDomainValidatorService validator, IShortUrlService shortUrl)
		{
			_validator = validator;
			_shortUrl = shortUrl;
		}

		[HttpGet("{id}")]
		public IActionResult GetShortUrl(int id)
		{
			string url = null;
			try
			{
				url = _shortUrl.GetUrl(id);
			}
			catch (ArgumentOutOfRangeException)
			{
				return NotFound();
			}

			if (string.IsNullOrEmpty(url))
				return NotFound();

			return RedirectPermanent(url);
		}

		[HttpPost("new")]
		public async Task<IActionResult> CreateShortUrl([FromForm] string url)
		{
			if (!await _validator.IsValidDomain(url))
				return Ok(_error); // Should be BadRequest, but FreeCodeCamp's tests throw on 4xx error codes

			var shortUrl = _shortUrl.AddUrl(url);

			return Created($"/shorturl/{shortUrl.ShortenedUrl}", shortUrl);
		}
	}
}