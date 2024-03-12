using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineRadarAI.Api.Models;

namespace CineRadarAI.Api.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetUsers();
        Task<ServiceResponse<User>> GetUserById(int id);
        Task<ServiceResponse<List<User>>> AddUser(User newUser);
    }
}