using System;
using System.Collections.Generic;

namespace BasicCRM.Api.Data.Entities
{
	public class CustomerEntity
	{
		public Guid Id { get; set; }
		public string DisplayName { get; set; }
		public ICollection<ProductEntity> Products { get; } = new List<ProductEntity>();
	}
}