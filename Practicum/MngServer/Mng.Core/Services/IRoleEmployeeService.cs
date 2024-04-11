using Mng.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.Services
{
    public interface IRoleEmployeeService
    {
        Task<IEnumerable<RoleEmployee>> GetAllAsync();

        Task<RoleEmployee> GetByIdAsync(int roleEmployeeId);

        Task<RoleEmployee> AddAsync(RoleEmployee roleEmployee);

        Task<RoleEmployee> UpdateAsync(RoleEmployee roleEmployee);

        Task DeleteAsync(int roleEmployeeId);
    }
}
