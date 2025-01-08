using Domain;
using Domain.Dto;

namespace Service
{
    public interface IUserService
    {
        Guid CreateUser(ProfileDto profileDto, Guid authId);
        Profile GetUser(Guid id);
    }
}
