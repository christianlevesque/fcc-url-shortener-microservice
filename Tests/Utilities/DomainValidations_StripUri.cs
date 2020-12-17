using Webapp.Utilities;
using Xunit;

namespace Tests.Utilities
{
	public class DomainValidations_StripUri
	{
		private const string DomainWithUri = "https://www.christianlevesque.io/home";
		private const string DomainWithoutUri = "https://www.christianlevesque.io";
		
		[Fact]
		public void StripUriReturnsDomainWhenUriPresent()
		{
			Assert.Equal(DomainWithoutUri, DomainValidations.StripUri(DomainWithUri));
		}

		[Fact]
		public void StripUriReturnsDomainWhenUriNotPresent()
		{
			Assert.Equal(DomainWithoutUri, DomainValidations.StripUri(DomainWithoutUri));
		}
	}
}