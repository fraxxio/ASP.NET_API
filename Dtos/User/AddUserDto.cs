using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineRadarAI.Api.Dtos.User
{
    public class AddUserDto
    {
        public string Name { get; set; } = "User";
        public string[] LikedMovies { get; set; } = [];
    }
}