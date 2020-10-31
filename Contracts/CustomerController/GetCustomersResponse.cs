using BasicCRM.Api.Models;
using System.Collections.Generic;

namespace BasicCRM.Api.Contracts.CustomerController
{
	public class GetCustomersResponse
	{
		public List<Customer> Customers { get; set; }
	}
}
