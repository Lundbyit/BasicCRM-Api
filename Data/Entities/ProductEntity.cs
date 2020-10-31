using System;
using System.Collections.Generic;

namespace BasicCRM.Api.Data.Entities
{
	public class ProductEntity
	{
		public Guid Id { get; set; }
		public string DisplayName { get; set; }
		public ICollection<CustomerEntity> Customers { get; } = new List<CustomerEntity>();
	}
}