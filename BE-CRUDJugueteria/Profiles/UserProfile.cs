using AutoMapper;
using BE_CRUDJugueteria.Models;
using BE_CRUDJugueteria.Models.DTO;

namespace BE_CRUDJugueteria.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
