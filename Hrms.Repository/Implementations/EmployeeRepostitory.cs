 using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using Hrms.Repository.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.Implementations
{
    public class EmployeeRepostitory : IEmployeeRepository
    {
        private readonly MyContext _myContext;

        public EmployeeRepostitory(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task <IList<Employee>> getAllEmployees()
        {

           var employees = await _myContext.Employees.ToListAsync();
            return employees;
        }
        public async Task <Employee> getElementById(int id)
        {
            var result = await _myContext.Employees.FindAsync(id);
            return result;
            throw new NotImplementedException();
        }

        public async Task<IList<EmpDept>> getEmpDetails(int? DeptId)
        {
            IList<EmpDept> list = await _myContext.EmployeeDetails.FromSqlRaw("exec usp_EmpDept {0}", DeptId).ToListAsync();
            return list;
        }

        public async Task<IList<EmpNames>> getEmpNames()
        {
            IList<EmpNames> list = await _myContext.EmployeeNames.FromSqlRaw(" exec usp_EmpGroup ").ToListAsync();
            return list;
        }

        public async Task <Employee> postEmployee(Employee emp)
        {
            var result = await _myContext.Employees.AddAsync(emp);
            await _myContext.SaveChangesAsync();
            return result.Entity;
            throw new NotImplementedException();
        }
    }
}
