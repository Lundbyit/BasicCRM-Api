using System;
using System.Collections.Generic;

namespace BasicCRM.Api.Models
{
	public class Product
	{
		public Guid Id { get; set; }
		public string DisplayName { get; set; }
		public List<ProductCustomer> Customers { get; set; }
	}
}
