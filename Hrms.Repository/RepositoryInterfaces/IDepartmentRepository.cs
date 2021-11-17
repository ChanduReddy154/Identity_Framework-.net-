using Hrms.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.RepositoryInterfaces
{
  public  interface IDepartmentRepository
    {
       Task< IList<Department>> getAllDepartments();

       Task <Department> postDepartments(Department depts);
    }
}
