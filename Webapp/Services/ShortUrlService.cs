using System.Collections.Generic;
using Webapp.Models;

namespace Webapp.Services
{
	public class ShortUrlService : IShortUrlService
	{
		public IList<string> Urls { get; } = new List<string>();

		public string GetUrl(int index)
		{
			return Urls[index];
		}

		public ShortUrl AddUrl(string url)
		{
			var shortUrl = new ShortUrl
			{
				OriginalUrl = url,
				ShortenedUrl = Urls.Count
			};
			Urls.Add(url);
			return shortUrl;
		}
	}
}