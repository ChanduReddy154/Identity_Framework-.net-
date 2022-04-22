using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.Business.BusinessInterfaces
{
    public interface IPersonalInfoInterface
    {

        public Task<PersonalInfoViewModel> postPersonalInfo(PersonalInfoViewModel personalInfo);
    }
}
