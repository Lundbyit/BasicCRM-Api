using BasicCRM.Api.Data.Entities;
using System;
using System.Collections.Generic;

namespace BasicCRM.Api.Data.Repositories
{
	public interface ICustomerRepository
	{
		CustomerEntity AddCustomer(string displayName);
		bool DeleteCustomer(Guid id);
		CustomerEntity GetCustomer(Guid id);
		List<CustomerEntity> GetCustomers();
		CustomerEntity AddProductToCustomer(Guid customerId, Guid productId);
		CustomerEntity DeleteProductForCustomer(Guid customerId, Guid productId);
	}
}