using Mng.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.Repositories
{
    public interface IRoleEmployeeRepository
    {
        Task<IEnumerable<RoleEmployee>> GetAllAsync();

        Task<RoleEmployee> GetByIdAsync(int employeeRoleId);

        Task<RoleEmployee> AddAsync(RoleEmployee employeeRole);

        Task<RoleEmployee> UpdateAsync(RoleEmployee employeeRole);

        Task DeleteAsync(int employeeRoleId);
    }
}
