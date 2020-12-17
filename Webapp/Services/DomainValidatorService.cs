using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Webapp.Utilities;

namespace Webapp.Services
{
	public class DomainValidatorService : IDomainValidatorService
	{
		private readonly HttpClient _client;

		public DomainValidatorService(HttpClient client)
		{
			_client = client;
		}

		public async Task<bool> IsValidDomain(string url)
		{
			url = DomainValidations.StripProtocol(url);
			url = DomainValidations.StripUri(url);

			// Get response
			var message = await _client.GetAsync($"https://dns.google.com/resolve?name={url}&type=A");
			if (!message.IsSuccessStatusCode)
				return false;
			
			var content = await message.Content.ReadAsStringAsync();
			var response = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(content);

			// Parse response
			if (response.TryGetValue("Status", out var value))
				return value.GetInt32() == 0;

			// Not valid
			return false;
		}
	}
}