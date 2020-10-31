using BasicCRM.Api.Contracts.CustomerController;
using BasicCRM.Api.Data.Repositories;
using BasicCRM.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BasicCRM.Api.Controllers
{
	public class CustomerController : ControllerBase
	{
		private ICustomerRepository _customerRepository;
		private ICustomerService _customerService;

		public CustomerController(ICustomerRepository customerRepository, ICustomerService customerService)
		{
			_customerRepository = customerRepository;
			_customerService = customerService;
		}

		[HttpGet]
		[Route("customer")]
		public IActionResult GetAllCustomers()
		{
			return Ok(_customerService.GetCustomers());
		}

		[HttpPost]
		[Route("customer")]
		public IActionResult AddCustomer(AddCustomerRequest request)
		{
			if (string.IsNullOrWhiteSpace(request.DisplayName))
			{
				return BadRequest();
			}

			return Ok(_customerService.AddCustomer(request));
		}

		[HttpGet]
		[Route("customer/{id}")]
		public IActionResult GetCustomer(string id)
		{
			Guid customerId;

			if (!Guid.TryParse(id, out customerId))
			{
				return BadRequest();
			}

			var response = _customerService.GetCustomer(customerId);

			if (response.Customer == null)
			{
				return NotFound();
			}

			return Ok(response);
		}

		[HttpDelete]
		[Route("customer/{id}")]
		public IActionResult DeleteCustomer(string id)
		{
			Guid customerId;

			if (!Guid.TryParse(id, out customerId))
			{
				return BadRequest();
			}

			_customerService.DeleteCustomer(customerId);

			return NoContent();
		}

		[HttpPut]
		[Route("customer/{customerId}/product/{productId}")]
		public IActionResult AddProductToCustomer(string customerId, string productId)
		{
			Guid customerGuid;
			Guid productGuid;

			if (!Guid.TryParse(customerId, out customerGuid) || !Guid.TryParse(productId, out productGuid))
			{
				return BadRequest();
			}

			var response = _customerService.AddProductToCustomer(customerGuid, productGuid);

			return Ok(response);
		}

		[HttpDelete]
		[Route("customer/{customerId}/product/{productId}")]
		public IActionResult DeleteProductForCustomer(string customerId, string productId)
		{
			Guid customerGuid;
			Guid productGuid;

			if (!Guid.TryParse(customerId, out customerGuid) || !Guid.TryParse(productId, out productGuid))
			{
				return BadRequest();
			}

			var response = _customerService.DeleteProductForCustomer(customerGuid, productGuid);

			return Ok(response);
		}
	}
}
