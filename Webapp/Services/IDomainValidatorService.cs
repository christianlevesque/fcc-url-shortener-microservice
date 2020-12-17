using System.Threading.Tasks;

namespace Webapp.Services
{
	public interface IDomainValidatorService
	{
		public Task<bool> IsValidDomain(string url);
	}
}