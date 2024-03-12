using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineRadarAI.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CineRadarAI.Api.Services.UserService
{
    public class UserService : IUserService
    {
        private static readonly List<User> users = new List<User>
        {
            new User(),
            new User { Id= 1, Name = "Alah" }
        };
        public async Task<ServiceResponse<List<User>>> AddUser(User newUser)
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            users.Add(newUser);
            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<User>();
            serviceResponse.Data = users.FirstOrDefault(u => u.Id == id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<User>>> GetUsers()
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            serviceResponse.Data = users;
            return serviceResponse;
        }
    }
}