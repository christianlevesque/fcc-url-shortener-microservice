using System.Text.RegularExpressions;

namespace Webapp.Utilities
{
	public static class DomainValidations
	{
		private static readonly Regex Regex = new Regex(@"^https?:\/\/");
		public static bool HasProtocol(string url)
		{
			return Regex.IsMatch(url);
		}
	}
}