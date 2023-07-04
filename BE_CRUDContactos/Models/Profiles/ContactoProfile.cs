using AutoMapper;
using BE_CRUDContactos.Models.DTO;

namespace BE_CRUDContactos.Models.Profiles
{
    public class ContactoProfile : Profile
    {
        public ContactoProfile() 
        {
            CreateMap<Contacto, ContactoDTO>();
            CreateMap<ContactoDTO, Contacto>();
        }    
    }
}
