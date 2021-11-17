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
  public  class DepartmentBusiness : IDepartmentBusiness
    {
        private readonly IDepartmentRepository _deptRepository;
        private readonly IMapper _mapper;

        public DepartmentBusiness(IDepartmentRepository deptRepository , IMapper mapper)
        {
            _deptRepository = deptRepository;
            _mapper = mapper;
        }
        
        public async Task <IList<DepartmentViewModel>>  getAllDepartments()
        {
            var depts = await _deptRepository.getAllDepartments();
            return _mapper.Map<IList<DepartmentViewModel>>(depts);

            //IList<DepartmentViewModel> result = new List<DepartmentViewModel>();

            //DepartmentViewModel dept;

            //foreach (Department item in depts)
            //{
            //    dept = new DepartmentViewModel()
            //    {
            //        DeptId = item.DeptId,
            //        DeptLocation = item.DeptLocation,
            //        DeptName = item.DeptName
            //    };
            //    result.Add(dept);
            //}
            //return result;
        }

        public async Task <DepartmentViewModel> PostDepartment(DepartmentViewModel dept)
        {
            var result = await _deptRepository.postDepartments(_mapper.Map<Department>(dept));
            return _mapper.Map<DepartmentViewModel>(result);
            throw new NotImplementedException();
        }
    }
}
