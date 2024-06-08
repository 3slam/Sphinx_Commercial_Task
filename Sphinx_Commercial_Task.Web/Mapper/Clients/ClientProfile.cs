using AutoMapper;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Web.ViewModels;

namespace Sphinx_Commercial_Task.Web.Mapper.Clients
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientViewModel, Client>().
            ForMember(desination => desination.Name, opt => opt.MapFrom(source => source.Name)).
            ForMember(desination => desination.State, opt => opt.MapFrom(source => source.State)).
            ForMember(desination => desination.Class, opt => opt.MapFrom(source => source.Class)).
            ReverseMap();

            CreateMap<EditClientViewModel, Client>().
           ForMember(desination => desination.Code, opt => opt.MapFrom(source => source.Code)).
        ForMember(desination => desination.Name, opt => opt.MapFrom(source => source.Name)).
        ForMember(desination => desination.State, opt => opt.MapFrom(source => source.State)).
        ForMember(desination => desination.Class, opt => opt.MapFrom(source => source.Class)).
        ReverseMap();

        }
    }
}
