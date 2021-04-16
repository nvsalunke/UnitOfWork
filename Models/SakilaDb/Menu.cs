using System;
using System.Collections.Generic;

namespace Multi_UnitOfWork.Models.SakilaDb
{
	public partial class Menu
	{
		public Menu()
		{
			InverseMenuParent = new HashSet<Menu>();
		}

		public int Id { get; set; }
		public string MenuName { get; set; }
		public int MenuLevel { get; set; }
		public int MenuOrder { get; set; }
		public int? MenuParentId { get; set; }
		public string MenuLink { get; set; }
		public bool? MenuActive { get; set; }

		public Menu MenuParent { get; set; }
		public ICollection<Menu> InverseMenuParent { get; set; }
	}
}
