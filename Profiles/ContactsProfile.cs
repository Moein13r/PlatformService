using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            //source -> target
            CreateMap<Contacts, ContactsReadDTo>();
            CreateMap<ContactsCreateDTo, Contacts>();
            CreateMap<ContactsReadDTo, ContactsCreateDTo>();
        }
    }
}