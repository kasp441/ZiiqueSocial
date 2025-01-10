using Domain;

namespace Repo
{
    public class ProfileRepo : IProfileRepo
    {
        RepoContext _context;
        public ProfileRepo(RepoContext context) 
        {
            _context = context;
        }
        public Profile AddProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
            return profile;
        }

        public List<Profile> GetAllProfiles()
        {
            return _context.Profiles.ToList();
        }

        public Profile GetProfile(Guid id)
        {
            return _context.Profiles.FirstOrDefault(p => p.Guid == id) ?? throw new Exception("Profile not found");
        }

        public void RemoveProfile(Guid id)
        {
            _context.Profiles.Remove(_context.Profiles.FirstOrDefault(p => p.Guid == id) ?? throw new Exception("Profile not found"));
        }

        public void UpdateProfile(Profile profile)
        {
            _context.Profiles.Update(profile);
            _context.SaveChanges();
        }
    }
}
