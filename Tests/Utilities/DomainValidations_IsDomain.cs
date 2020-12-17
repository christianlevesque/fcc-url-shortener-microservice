using System.Threading.Tasks;
using Webapp.Utilities;
using Xunit;

namespace Tests.Utilities
{
	public class DomainValidations_IsDomain
	{
		[Fact]
		public async Task IsDomainReturnsTrueIfDomainExists()
		{
			Assert.True(await DomainValidations.IsDomain("www.christianlevesque.io"));
		}

		[Fact]
		public async Task IsDomainReturnsFalseIfDomainNotExists()
		{
			Assert.False(await DomainValidations.IsDomain("christianlevesque"));
			Assert.False(await DomainValidations.IsDomain("christian levesque"));
		}

		[Fact]
		public async Task IsDomainReturnsTrueIfHttpPresent()
		{
			Assert.True(await DomainValidations.IsDomain("http://www.christianlevesque.io"));
		}
	}
}