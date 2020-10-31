using AutoMapper;
using BasicCRM.Api.Contracts.CustomerController;
using BasicCRM.Api.Data.Repositories;
using BasicCRM.Api.Models;
using BasicCRM.Api.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace BasicCRM.Api.Services
{
	public class CustomerService : ICustomerService
	{
		private ICustomerRepository _customerRepository;
		private IMapper _mapper;

		public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
		{
			_customerRepository = customerRepository;
			_mapper = mapper;
		}

		public AddCustomerResponse AddCustomer(AddCustomerRequest request)
		{
			var newCustomer = _customerRepository.AddCustomer(request.DisplayName);

			return new AddCustomerResponse
			{
				Customer = _mapper.Map<Customer>(newCustomer)
			};
		}

		public AddProductToCustomerResponse AddProductToCustomer(Guid customerId, Guid productId)
		{
			var customer = _customerRepository.AddProductToCustomer(customerId, productId);

			return new AddProductToCustomerResponse
			{
				Customer = _mapper.Map<Customer>(customer)
			};
		}

		public bool DeleteCustomer(Guid customerId)
		{
			return _customerRepository.DeleteCustomer(customerId);
		}

		public DeleteProductForCustomerResponse DeleteProductForCustomer(Guid customerId, Guid productId)
		{
			var customer = _customerRepository.DeleteProductForCustomer(customerId, productId);

			return new DeleteProductForCustomerResponse
			{
				Customer = _mapper.Map<Customer>(customer)
			};
		}

		public GetCustomersResponse GetCustomers()
		{
			var customers = _customerRepository.GetCustomers();

			return new GetCustomersResponse
			{
				Customers = _mapper.Map<List<Customer>>(customers)
			};
		}

		public GetCustomerResponse GetCustomer(Guid customerId)
		{
			var customer = _customerRepository.GetCustomer(customerId);

			return new GetCustomerResponse
			{
				Customer = _mapper.Map<Customer>(customer)
			};
		}
	}
}
