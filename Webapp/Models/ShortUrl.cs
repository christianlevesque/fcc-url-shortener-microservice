using System.Text.Json.Serialization;

namespace Webapp.Models
{
	public class ShortUrl
	{
		[JsonPropertyName("original_url")]
		public string OriginalUrl { get; set; }
		
		[JsonPropertyName("short_url")]
		public int ShortenedUrl { get; set; }
	}
}