using AutoMapper;
using Domain.Dto;
using Repo;
using Profile = Domain.Profile;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IProfileRepo _profileRepo;
        private readonly IMapper _mapper;

        public UserService(IProfileRepo profileRepo, IMapper mapper)
        {
            _profileRepo = profileRepo;
            _mapper = mapper;
        }

        public Guid CreateUser(ProfileDto profileDto, Guid authId)
        {
            //map to domain objects
            var profile = _mapper.Map<Profile>(profileDto);
            profile.Guid = authId;

            return _profileRepo.AddProfile(profile).Guid;
        }

        public Profile GetUser(Guid id)
        {
            return _profileRepo.GetProfile(id);
        }
    }
}
