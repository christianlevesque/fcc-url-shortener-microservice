using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Webapp.Utilities
{
	public static class DomainValidations
	{
		private static readonly Regex HttpRegex = new Regex(@"^https?:\/\/");
		public static bool HasProtocol(string url)
		{
			return HttpRegex.IsMatch(url);
		}

		public static string StripProtocol(string url)
		{
			return HttpRegex.Replace(url, "");
		}

		public static string StripUri(string url)
		{
			// Regex need
			//
			// Must identify the /home/whatever?q=something  portion of a URL
			// If `url` is a valid URL, it will have a TLD extension
			// So to differentiate between the http:// forward slashes
			// and the /home/whatever forward slashes, we check to see
			// if a TLD extension has occurred yet using a lookbehind
			// by checking for a dot followed by any number of characters
			
			// Regex breakdown
			//
			// \/                 Match a literal forward slash
			//   (?<=             ...<preceded by>...
			//       (\..*)       ...a literal period followed by any number of characters...
			//             )      ...</preceded by>...
			//              .*$   ...and match the rest of the string
			return Regex.Replace(url, @"\/(?<=(\..*)).*$", "");
		}

		public static async Task<bool> IsDomain(string url)
		{
			url = StripProtocol(url);
			url = StripUri(url);
			
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