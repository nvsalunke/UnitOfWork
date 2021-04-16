using System.Threading.Tasks;
using Multi_UnitOfWork.Services;
using Microsoft.AspNetCore.Mvc;

namespace Multi_UnitOfWork.Controllers
{
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var result = await _productService.GetProducts();
			return Ok(result);
		}
	}
}