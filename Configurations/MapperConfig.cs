using AmigoCars.DTOs.Incoming;
using AmigoCars.DTOs.Outgoing;
using AmigoCars.Models;
using AutoMapper;

namespace AmigoCars.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<UserLoginDto,User>();
           CreateMap<User, UsersOutgoingDto>();
          CreateMap<Role,UsersOutgoingDto>();
            CreateMap<CarDetail, CreateCarDto>();
            CreateMap<Address, UsersOutgoingDto>();
            CreateMap<GetUserDetailsDto, User>().ForMember(dest=>dest.LastLogin, opt=>opt.MapFrom(src=>DateTime.Now))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        }
    }
}
