using Mng.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        
        Task<Employee> GetByIdAsync(int employeeId);

        Task<bool> AddAsync(Employee employee);

        Task<bool> UpdateAsync(Employee employee);

        Task DeleteAsync(int employeeId);

    }
}
