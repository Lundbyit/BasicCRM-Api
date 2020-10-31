using BasicCRM.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicCRM.Api.Data.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private InMemoryDataContext _context;
		private IProductRepository _productRepository;

		public CustomerRepository(InMemoryDataContext context, IProductRepository productRepository)
		{
			_context = context;
			_productRepository = productRepository;
		}

		public CustomerEntity AddCustomer(string displayName)
		{
			var newCustomer = new CustomerEntity
			{
				Id = Guid.NewGuid(),
				DisplayName = displayName,
			};

			_context.Add(newCustomer);
			_context.SaveChanges();

			return newCustomer;
		}

		public List<CustomerEntity> GetCustomers()
		{
			return _context.Customers.Include(customer => customer.Products).ToList();
		}

		public CustomerEntity GetCustomer(Guid id)
		{
			return _context.Customers.Include(customer => customer.Products).FirstOrDefault(customer => customer.Id == id);
		}

		public bool DeleteCustomer(Guid id)
		{
			try
			{
				var customerToDelete = _context.Customers.FirstOrDefault(customer => customer.Id == id);
				_context.Remove(customerToDelete);
				_context.SaveChanges();

				return true;
			}
			catch (Exception)
			{
				//Todo: log exception
				return false;
			}
		}

		public CustomerEntity AddProductToCustomer(Guid customerGuid, Guid productGuid)
		{
			var customer = GetCustomer(customerGuid);
			var product = _productRepository.GetProduct(productGuid);

			customer.Products.Add(product);
			_context.SaveChanges();

			return customer;
		}

		public CustomerEntity DeleteProductForCustomer(Guid customerGuid, Guid productGuid)
		{
			var customer = GetCustomer(customerGuid);
			var product = customer.Products.FirstOrDefault(product => product.Id == productGuid);

			if (product == null)
			{
				return customer;
			}

			customer.Products.Remove(product);
			_context.SaveChanges();

			return customer;
		}
	}
}
