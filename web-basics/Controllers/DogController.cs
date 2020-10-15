using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DogController : ControllerBase
	{
		private readonly business.Domains.DogDomain _dogDomain;
		public DogController(IConfiguration configuration)
		{
			_dogDomain = new business.Domains.DogDomain(configuration);
		}

		[HttpGet]
		public IActionResult Get() => Ok(_dogDomain.Get());

		[HttpPost]
		public IActionResult Add([FromBody] DogView dogView)
		{
			if (string.IsNullOrWhiteSpace(dogView.Name) || dogView.Age < 0)
			{
				return BadRequest();
			}

			int? result =_dogDomain.Add(dogView);
			if (result.HasValue)
			{
				dogView.Id = result.Value;
				return Ok(dogView);
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
