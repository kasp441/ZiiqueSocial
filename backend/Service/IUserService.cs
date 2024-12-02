using Domain.Dto;

namespace Service
{
    public interface IUserService
    {
        ProfileDto CreateUser(ProfileDto profileDto, string authId);
    }
}
