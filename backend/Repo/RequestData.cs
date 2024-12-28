using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto;

namespace Repo
{
    public class RequestData : IRequestData
    {

        private readonly RepoContext _context;
        public RequestData(RepoContext context)
        {
            _context = context;
        }


        public UserDataDto GetProfileData(Guid id)
        {
            Profile profile = _context.Profiles.FirstOrDefault(p => p.Guid == id);
            List<Post> posts = _context.Posts.Where(p => p.ProfileId == id).ToList();
            List<Follows> follows = _context.Follows.Where(p => p.profile.Guid == id).ToList();

            return new UserDataDto
            {
                Profile = profile,
                Posts = posts,
                Follows = follows
            };
        }
    }
}
