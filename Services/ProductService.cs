using AutoMapper;
using BasicCRM.Api.Contracts.ProductController;
using BasicCRM.Api.Data;
using BasicCRM.Api.Data.Repositories;
using BasicCRM.Api.Models;
using BasicCRM.Api.Services.Interfaces;
using System;
using System.Linq;

namespace BasicCRM.Api.Services
{
	public class ProductService : IProductService
	{
		private IMapper _mapper;
		private IProductRepository _productRepository;

		public ProductService(IMapper mapper, IProductRepository productRepository)
		{
			_mapper = mapper;
			_productRepository = productRepository;
		}

		public AddProductResponse AddProduct(string displayName)
		{
			var product = _productRepository.AddProduct(displayName);

			return new AddProductResponse
			{
				Product = _mapper.Map<Product>(product)
			};
		}

		public bool DeleteProduct(Guid productId)
		{
			return _productRepository.DeleteProduct(productId);
		}

		public GetProductResponse GetProduct(Guid productId)
		{
			var product = _productRepository.GetProduct(productId);

			return new GetProductResponse
			{
				Product = _mapper.Map<Product>(product)
			};
		}

		public GetProductsResponse GetProducts()
		{
			var products = _productRepository.GetProducts();

			return new GetProductsResponse
			{
				Products = products.Select(product => _mapper.Map<Product>(product)).ToList()
			};
		}
	}
}
