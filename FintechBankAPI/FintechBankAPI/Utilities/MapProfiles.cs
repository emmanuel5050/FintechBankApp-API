using AutoMapper;
using FintechBankAPI.DTOs;
using FintechBankAPI.Entities;

namespace FintechBankAPI.Utilities
{
    public class MapInitializer:Profile
    {
        //public Mapper regMapper { get; set; }
        public MapInitializer()
        {
            //var regConfig = new MapperConfiguration(conf => conf.CreateMap<RegisterDTO, AppUser>());
            //regMapper = new Mapper(regConfig);
            CreateMap<RegisterDTO, Customer>().ReverseMap();
            CreateMap<RegisterDTO, AppUser>();

        }
    }
}
