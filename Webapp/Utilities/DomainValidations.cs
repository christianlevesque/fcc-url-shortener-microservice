using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Webapp.Utilities
{
	public static class DomainValidations
	{
		private static readonly Regex Regex = new Regex(@"^https?:\/\/");
		public static bool HasProtocol(string url)
		{
			return Regex.IsMatch(url);
		}

		public static string StripProtocol(string url)
		{
			return Regex.Replace(url, "");
		}

		public static async Task<bool> IsDomain(string url)
		{
			url = StripProtocol(url);
			IPHostEntry domain;
			try
			{
				domain = await Dns.GetHostEntryAsync(url);
			}
			catch (SocketException)
			{
				return false;
			}

			return !domain.HostName.EndsWith(".home");
		}
	}
}