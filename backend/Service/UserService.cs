using Domain.Dto;


namespace Service
{
    public class UserService : IUserService
    {
        ProfileDto IUserService.CreateUser(LoginDto loginDto, ProfileDto profileDto)
        {
            throw new NotImplementedException();
        }
    }
}
