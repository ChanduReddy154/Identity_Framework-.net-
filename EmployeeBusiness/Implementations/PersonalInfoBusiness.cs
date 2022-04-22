using AutoMapper;
using Hrms.Business.BusinessInterfaces;
using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.Business.Implementations
{
    public class PersonalInfoBusiness : IPersonalInfoInterface
    {

        private readonly IPersonalRepoInterface _personalRepoInterface;
        private readonly IMapper _mapper;

        public PersonalInfoBusiness(IPersonalRepoInterface personalRepoInterface, IMapper mapper)
        {
            _personalRepoInterface = personalRepoInterface;
            _mapper = mapper;
        }
        public async Task<PersonalInfoViewModel> postPersonalInfo(PersonalInfoViewModel personalInfo)
        {
            var result = await _personalRepoInterface.postPerdonalInformation(_mapper.Map<PersonalInformation>(personalInfo));
            return _mapper.Map<PersonalInfoViewModel>(result);
        }
    }
}
