using BasicCRM.Api.Models;
using System.Collections.Generic;

namespace BasicCRM.Api.Contracts.ProductController
{
	public class GetProductsResponse
	{
		public List<Product> Products { get; set; }
	}
}
