using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IProfileRepo
    {
        Profile GetProfile(Guid id);

        List<Profile> GetAllProfiles();
        Profile AddProfile(Profile profile);

        void RemoveProfile(Guid id);

        void UpdateProfile(Profile profile);
    }
}
