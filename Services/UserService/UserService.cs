using CineRadarAI.Api.Data;

namespace CineRadarAI.Api.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(DataContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var users = await _dbContext.Users.ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetUserDto>>(users);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var users = await _dbContext.Users.ToListAsync();
            serviceResponse.Data = _mapper.Map<GetUserDto>(users.FirstOrDefault(u => u.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var users = await _dbContext.Users.ToListAsync();
            var user = _mapper.Map<User>(newUser);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            serviceResponse.Data = _dbContext.Users
                .Select(_mapper.Map<GetUserDto>)
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            var users = await _dbContext.Users.ToListAsync();
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
                if (user is null)
                    throw new Exception($"User with ID '{updatedUser.Id}' is not found.");

                _mapper.Map(updatedUser, user);
                await _dbContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
                serviceResponse.Message = "User deleted successfully.";
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccesful = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var user = await _dbContext.Users.FindAsync(id);
                if (user == null)
                    throw new Exception($"User with ID '{id}' is not found.");

                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();

                var updatedUsers = await _dbContext.Users.ToListAsync();
                serviceResponse.Data = updatedUsers.Select(_mapper.Map<GetUserDto>).ToList();
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