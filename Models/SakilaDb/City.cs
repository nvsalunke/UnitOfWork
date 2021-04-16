using System;
using System.Collections.Generic;

namespace Multi_UnitOfWork.Models.SakilaDb
{
	public partial class City
	{
		public City()
		{
			Address = new HashSet<Address>();
		}

		public int CityId { get; set; }
		public string City1 { get; set; }
		public short CountryId { get; set; }
		public DateTime LastUpdate { get; set; }

		public Country Country { get; set; }
		public ICollection<Address> Address { get; set; }
	}
}
