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
   public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _empRepository;
        private readonly IMapper _mapper;

        public EmployeeBusiness(IEmployeeRepository empRepository, IMapper mapper)
        {
            _empRepository = empRepository;
            _mapper = mapper;
        }

        public Task<EmployeeViewModel> deleteEmployee(EmployeeViewModel emp)
        {
            throw new NotImplementedException();
        }

        public async Task <IList<EmployeeViewModel>> getAllEmployees()
        {
            var employees = await _empRepository.getAllEmployees();
            return _mapper.Map<IList<EmployeeViewModel>>(employees);
            //IList<EmployeeViewModel> result = new List<EmployeeViewModel>();
            //EmployeeViewModel emp;

            //foreach (Employee item in employees)
            //{
            //    emp = new EmployeeViewModel()
            //    {
            //        EmpId = item.EmpId,
            //        EmpName = item.EmpName,
            //        EmpSalary = item.EmpSalary,
            //        DeptId = item.DeptId
            //    };
            //    result.Add(emp);

            //}
            //return result;
        }

        public async Task <EmployeeViewModel> getElementById(int id)
        {
            var result = await _empRepository.getElementById(id);

            return _mapper.Map<EmployeeViewModel>(result);
        }

        public async Task<IList<EmpDetailsViewModel>> getEmpDetails(int? DeptId)
        {
            var result = await _empRepository.getEmpDetails(DeptId);
            return _mapper.Map<IList<EmpDetailsViewModel>>(result);
        }

        public async Task<IList<EmpNameViewModel>> getEmpNames()
        {

            var result = await _empRepository.getEmpNames();
            return _mapper.Map<IList<EmpNameViewModel>>(result);
           // throw new NotImplementedException();
        }

        public async Task <EmployeeViewModel> postEmployee(EmployeeViewModel emp)
        {
            var result = await _empRepository.postEmployee(_mapper.Map<Employee>(emp));
           return _mapper.Map<EmployeeViewModel>(result);
           // throw new NotImplementedException();
        }

        public async Task<EmployeeViewModel> updateEmployee(EmployeeViewModel emp)
        {
            var result = await _empRepository.UpdateEmployee(_mapper.Map<Employee>(emp));
            return _mapper.Map<EmployeeViewModel>(result);
        }
    }
}
