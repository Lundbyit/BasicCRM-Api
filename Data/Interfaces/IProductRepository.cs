using BasicCRM.Api.Data.Entities;
using System;
using System.Collections.Generic;

namespace BasicCRM.Api.Data
{
	public interface IProductRepository
	{
		ProductEntity AddProduct(string displayName);
		List<ProductEntity> GetProducts();
		ProductEntity GetProduct(Guid id);
		bool DeleteProduct(Guid id);
	}
}
