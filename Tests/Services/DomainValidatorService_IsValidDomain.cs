using System.Net.Http;
using System.Threading.Tasks;
using Webapp.Services;
using Xunit;

namespace Tests.Services
{
	public class DomainValidatorService_IsValidDomain
	{
		[Fact]
		public async Task IsValidDomainReturnsFalseIfDomainNotExists()
		{
			var service = new DomainValidatorService(new HttpClient());
			
			Assert.False(await service.IsValidDomain("christian levesque io"));
		}

		[Fact]
		public async Task IsValidDomainReturnsTrueIfDomainExists()
		{
			var service = new DomainValidatorService(new HttpClient());

			Assert.True(await service.IsValidDomain("christianlevesque.io"));
		}

		[Fact]
		public async Task IsValidDomainReturnsTrueIfUriPresent()
		{
			var service = new DomainValidatorService(new HttpClient());

			Assert.True(await service.IsValidDomain("christianlevesque.io/blog"));
		}

		[Fact]
		public async Task IsValidDomainReturnsTrueIfProtocolPresent()
		{
			var service = new DomainValidatorService(new HttpClient());

			Assert.True(await service.IsValidDomain("https://www.christianlevesque.io"));
		}
	}
}