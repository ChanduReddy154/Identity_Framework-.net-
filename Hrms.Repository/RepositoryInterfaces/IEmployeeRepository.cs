using Hrms.Repository.Models;
using Hrms.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.RepositoryInterfaces
{
   public interface IEmployeeRepository
    {
       Task <IList<Employee>> getAllEmployees();

       Task <Employee> postEmployee(Employee emp);

       Task <Employee> getElementById(int id);

        Task<IList<EmpDept>> getEmpDetails(int? DeptId);

        Task<IList<EmpNames>> getEmpNames();
    }
}
