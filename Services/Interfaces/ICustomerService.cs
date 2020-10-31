using BasicCRM.Api.Contracts.CustomerController;
using System;

namespace BasicCRM.Api.Services.Interfaces
{
	public interface ICustomerService
	{
		AddCustomerResponse AddCustomer(AddCustomerRequest request);
		AddProductToCustomerResponse AddProductToCustomer(Guid customerId, Guid productId);
		bool DeleteCustomer(Guid customerId);
		DeleteProductForCustomerResponse DeleteProductForCustomer(Guid customerId, Guid productId);
		GetCustomersResponse GetCustomers();
		GetCustomerResponse GetCustomer(Guid customerId);
	}
}
