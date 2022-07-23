using AutoMapper;
using ContactList.DTO;
using ContactList.Entity;

namespace ContactList.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Person, PersonReqDTO>().ReverseMap();
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Contact, ContactReqDTO>().ReverseMap();
            CreateMap<Contact, ContactReqUpdateDTO>().ReverseMap();
        }
    }
}
