using System;
using System.Collections.Generic;
using api_pract.Models.NorthwindDb;

namespace Multi_UnitOfWork.Models.NorthwindDb
{
	public partial class Categories
	{
		public Categories()
		{
			Products = new HashSet<Products>();
		}

		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }

		public ICollection<Products> Products { get; set; }
	}
}
