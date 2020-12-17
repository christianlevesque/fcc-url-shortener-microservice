using Webapp.Models;

namespace Webapp.Services
{
	public interface IShortUrlService
	{
		public string GetUrl(int index);
		public ShortUrl AddUrl(string url);
	}
}