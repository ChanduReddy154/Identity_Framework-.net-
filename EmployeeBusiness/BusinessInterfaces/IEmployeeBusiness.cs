using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.Business.BusinessInterfaces
{
   public interface IEmployeeBusiness
    {
       Task <IList<EmployeeViewModel>> getAllEmployees();

       Task <EmployeeViewModel> postEmployee(EmployeeViewModel emp);

       Task <EmployeeViewModel> getElementById(int id);

        Task<IList<EmpDetailsViewModel>> getEmpDetails(int? DeptId);

        Task<IList<EmpNameViewModel>> getEmpNames();

        Task<EmployeeViewModel> updateEmployee(EmployeeViewModel emp);

       Task<EmployeeViewModel> deleteEmployee(EmployeeViewModel emp);

    }
}
