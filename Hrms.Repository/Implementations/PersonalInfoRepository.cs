using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.Implementations
{
    public class PersonalInfoRepository : IPersonalRepoInterface
    {

        private readonly MyContext _myContext;

        public PersonalInfoRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        
        public async Task<PersonalInformation> postPerdonalInformation(PersonalInformation personalInformation)
        {
            var result = await _myContext.PersonalInformations.AddAsync(personalInformation);
            await _myContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
