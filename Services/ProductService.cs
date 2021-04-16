
using System.Collections.Generic;
using System.Threading.Tasks;
using Multi_UnitOfWork.Core;
using Multi_UnitOfWork.Models.NorthwindDb;
using Microsoft.EntityFrameworkCore;
using api_pract.Models.NorthwindDb;

namespace Multi_UnitOfWork.Services
{
	#region Interface
	public interface IProductService
	{
		Task<IEnumerable<Products>> GetProducts();
	}
	#endregion

	#region Implementation
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductService(IUnitOfWorkMultiContext unitOfWork)
		{
			_unitOfWork = unitOfWork.Get("NorthwindDbConnection");
		}
		public async Task<IEnumerable<Products>> GetProducts()
		{
			var result = await _unitOfWork.Set<Products>().ToListAsync();
			return result;
		}
	}
	#endregion

}