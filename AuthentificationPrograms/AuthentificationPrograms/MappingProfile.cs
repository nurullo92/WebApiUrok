using AuthentificationPrograms.Models;
using AutoMapper;

namespace AuthentificationPrograms
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            CreateMap<User, UserViewModel>().ConstructUsing(u => new UserViewModel(u));
        }
    }
}
