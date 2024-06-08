using AutoMapper;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Mapper.ClientProducts
{
    public class ClientProductProfile : Profile
    {
        public ClientProductProfile()
        {
            CreateMap<ClientProduct, ClientProductViewModel>()
             .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
             .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
              .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
             .ForMember(dest => dest.License, opt => opt.MapFrom(src => src.License));


            CreateMap<ClientProduct, EditClientProductViewModel>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
             .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
              .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
             .ForMember(dest => dest.License, opt => opt.MapFrom(src => src.License)).ReverseMap();
        }
    }
}
