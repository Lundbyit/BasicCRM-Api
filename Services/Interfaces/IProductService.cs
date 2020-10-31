using BasicCRM.Api.Contracts.ProductController;
using System;

namespace BasicCRM.Api.Services
{
	public interface IProductService
	{
		AddProductResponse AddProduct(string displayName);
		bool DeleteProduct(Guid productId);
		GetProductResponse GetProduct(Guid productId);
		GetProductsResponse GetProducts();
	}
}