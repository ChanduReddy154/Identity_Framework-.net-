using Hrms.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.RepositoryInterfaces
{
   public interface IPersonalRepoInterface
    {

        public Task<PersonalInformation> postPerdonalInformation(PersonalInformation personalInformation);

    }
}
