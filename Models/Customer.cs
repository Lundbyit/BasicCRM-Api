using System;
using System.Collections.Generic;

namespace BasicCRM.Api.Models
{
	public class Customer
	{
		public Guid Id { get; set; }
		public string DisplayName { get; set; }
		public List<CustomerProduct> Products { get; set; }
	}
}
