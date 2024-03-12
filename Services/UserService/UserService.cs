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
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var user = _mapper.Map<User>(newUser);
            user.Id = users.Max(c => c.Id) + 1;
            users.Add(user);
            serviceResponse.Data = users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user is null)
                    throw new Exception($"User with ID '{id}' is not found.");

                users.Remove(user);
                serviceResponse.Data = users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccesful = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            serviceResponse.Data = _mapper.Map<GetUserDto>(users.FirstOrDefault(u => u.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            serviceResponse.Data = users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
                if (user is null)
                    throw new Exception($"User with ID '{updatedUser.Id}' is not found.");

                _mapper.Map(updatedUser, user);
                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccesful = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}