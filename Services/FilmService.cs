using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Multi_UnitOfWork.Core;
using Multi_UnitOfWork.Models.SakilaDb;

namespace Multi_UnitOfWork.Services
{
	#region Interface
	public interface IFilmService
	{
		Task<IEnumerable<Film>> GetFilms();
	}
	#endregion
	#region  Implementation
	public class FilmService : IFilmService
	{
		private readonly IUnitOfWork _unitOfWork;

		public FilmService(IUnitOfWorkMultiContext unitOfWork)
		{
			_unitOfWork = unitOfWork.Get("SakilaDbConnection");
		}
		public async Task<IEnumerable<Film>> GetFilms()
		{
			return await _unitOfWork.Set<Film>().ToListAsync();
		}
	}
	#endregion
}