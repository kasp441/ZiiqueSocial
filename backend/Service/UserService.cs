using AutoMapper;
using Domain;
using Domain.Dto;
using Repo;


namespace Service
{
    public class UserService : IUserService
    {
        IProfileRepo _profileRepo;
        private IMapper _mapper;

        public UserService(IProfileRepo ProfileRepo, IMapper mapper)
        {
            _profileRepo = ProfileRepo;
            _mapper = mapper;
        }

        public ProfileDto CreateUser(ProfileDto profileDto, string AuthId)
        {
            //map to domain objects
            var profile = _mapper.Map<Domain.Profile>(profileDto);

            profile.authId = AuthId;

            return _mapper.Map<ProfileDto>(_profileRepo.AddProfile(profile));
        }
    }
}
