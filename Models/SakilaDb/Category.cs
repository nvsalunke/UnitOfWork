﻿using System;
using System.Collections.Generic;

namespace Multi_UnitOfWork.Models.SakilaDb
{
	public partial class Category
	{
		public Category()
		{
			FilmCategory = new HashSet<FilmCategory>();
		}

		public byte CategoryId { get; set; }
		public string Name { get; set; }
		public DateTime LastUpdate { get; set; }

		public ICollection<FilmCategory> FilmCategory { get; set; }
	}
}
