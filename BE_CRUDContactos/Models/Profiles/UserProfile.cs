using AutoMapper;
using BE_CRUDContactos.Models.DTO;
using System.Diagnostics.Contracts;

namespace BE_CRUDContactos.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<InputUserDTO, User>();  
            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();
            CreateMap<InputContactDTO, Contact>();
        }
    }
}
