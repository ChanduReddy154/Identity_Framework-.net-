using AutoMapper;
using Hrms.Repository.Models;
using Hrms.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Utilities
{
     public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<EmpDetailsViewModel, EmpDept>().ReverseMap();
            CreateMap<EmpNameViewModel, EmpNames>().ReverseMap();
            CreateMap<AppUser, UserViewModel>().ReverseMap();
        }
    }
}
