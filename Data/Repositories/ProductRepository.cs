using BasicCRM.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicCRM.Api.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private InMemoryDataContext _context;

		public ProductRepository(InMemoryDataContext context)
		{
			_context = context;
		}
		
		public ProductEntity AddProduct(string displayName)
		{
			var newProduct = new ProductEntity
			{
				Id = Guid.NewGuid(),
				DisplayName = displayName,
			};

			_context.Add(newProduct);
			_context.SaveChanges();

			return newProduct;
		}

		public List<ProductEntity> GetProducts()
		{
			return _context.Products.Include(product => product.Customers).ToList();
		}
		
		public ProductEntity GetProduct(Guid id)
		{
			return _context.Products.Include(product => product.Customers).FirstOrDefault(product => product.Id == id);
		}

		public bool DeleteProduct(Guid id)
		{
			try
			{
				var productToDelete = _context.Products.FirstOrDefault(product => product.Id == id);
				_context.Remove(productToDelete);
				_context.SaveChanges();

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
