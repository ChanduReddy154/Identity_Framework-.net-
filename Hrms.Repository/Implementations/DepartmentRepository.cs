using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.Implementations
{
   public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HrmsDBContext _myContext;

        public DepartmentRepository(HrmsDBContext myContext)
        {
            _myContext = myContext;
        }

        public async Task <IList<Department>> getAllDepartments()
        {
            var depts = await _myContext.Departments.ToListAsync();
            return depts;
            throw new NotImplementedException();
        }

        public async Task< Department> postDepartments(Department depts)
        {
            var result = await _myContext.Departments.AddAsync(depts);
           await _myContext.SaveChangesAsync();
            return result.Entity;
            throw new NotImplementedException();
        }
    }
}
