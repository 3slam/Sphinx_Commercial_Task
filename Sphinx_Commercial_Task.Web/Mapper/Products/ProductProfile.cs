using AutoMapper;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Mapper.Products
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductViewModel, Product>().
			ForMember(desination => desination.Name, opt => opt.MapFrom(source => source.Name)).
			ForMember(desination => desination.Description, opt => opt.MapFrom(source => source.Description)).
			ForMember(desination => desination.IsActive, opt => opt.MapFrom(source => source.IsActive)).
			ReverseMap();

		}
	}
}
