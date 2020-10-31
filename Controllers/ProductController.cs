using BasicCRM.Api.Contracts.ProductController;
using BasicCRM.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BasicCRM.Api.Controllers
{
	public class ProductController : ControllerBase
	{
		private IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		[Route("product")]
		public IActionResult GetAllProducts()
		{
			return Ok(_productService.GetProducts());
		}

		[HttpPost]
		[Route("product")]
		public IActionResult AddProduct(AddProductRequest request)
		{
			var response = _productService.AddProduct(request.DisplayName);

			return Ok(response);
		}

		[HttpGet]
		[Route("product/{id}")]
		public IActionResult GetProduct(string id)
		{
			Guid productId;

			if (!Guid.TryParse(id, out productId))
			{
				return BadRequest();
			}

			var response = _productService.GetProduct(productId);

			if (response == null)
			{
				return NotFound();
			}

			return Ok(response);
		}

		[HttpDelete]
		[Route("product/{id}")]
		public IActionResult DeleteProduct(string id)
		{
			Guid productId;

			if (!Guid.TryParse(id, out productId))
			{
				return BadRequest();
			}

			_productService.DeleteProduct(productId);

			return NoContent();
		}
	}
}
