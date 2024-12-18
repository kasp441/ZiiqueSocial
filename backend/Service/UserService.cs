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

        public Guid CreateUser(ProfileDto profileDto)
        {
            //map to domain objects
            var profile = _mapper.Map<Domain.Profile>(profileDto);


            return _profileRepo.AddProfile(profile).Guid;
        }
    }
}
