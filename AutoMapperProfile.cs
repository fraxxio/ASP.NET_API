using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineRadarAI.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}