using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Multi_UnitOfWork.Models.Config;
using Multi_UnitOfWork.Services;

namespace Multi_UnitOfWork.Controllers
{
	[Route("api/[controller]")]
	public class FilmController : ControllerBase
	{
		private readonly IFilmService _filmService;
		private readonly IOptions<ApplicationSettings> _appSetting;

		public FilmController(IFilmService filmService, IOptions<ApplicationSettings> applicationSetting)
		{
			_filmService = filmService;
			_appSetting = applicationSetting;
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var result = await _filmService.GetFilms();
			return Ok(result);
		}
	}
}