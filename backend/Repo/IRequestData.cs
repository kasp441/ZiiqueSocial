using Domain;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IRequestData
    {
        UserDataDto GetProfileData(Guid id);
    }
}
