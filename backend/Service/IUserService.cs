using Domain.Dto;

namespace Service
{
    public interface IUserService
    {
        ProfileDto CreateUser(LoginDto loginDto, ProfileDto profileDto);
    }
}
