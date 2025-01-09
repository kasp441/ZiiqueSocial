using Domain;

namespace Repo
{
    public interface IProfileRepo
    {
        Profile GetProfile(Guid id);
        
        Profile AddProfile(Profile profile);

        void RemoveProfile(Guid id);

        void UpdateProfile(Profile profile);
    }
}
