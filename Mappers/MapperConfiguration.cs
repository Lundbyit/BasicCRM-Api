using AutoMapper;
using BasicCRM.Api.Data.Entities;
using BasicCRM.Api.Models;

namespace BasicCRM.Api.Mappers
{
	public class MapperConfiguration : Profile
	{
		public MapperConfiguration()
		{
			CreateMap<CustomerEntity, Customer>();
			CreateMap<CustomerEntity, ProductCustomer>();
			CreateMap<ProductEntity, CustomerProduct>();
			CreateMap<ProductEntity, Product>();
		}
	}
}
