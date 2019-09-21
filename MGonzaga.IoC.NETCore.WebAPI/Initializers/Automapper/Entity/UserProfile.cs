using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGonzaga.IoC.NETCore.WebAPI.Initializers.Automapper.Entity
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Models.User, Common.Resources.Models.User>();
            CreateMap<Common.Resources.Models.User,Domain.Models.User>();
        }
    }
}
