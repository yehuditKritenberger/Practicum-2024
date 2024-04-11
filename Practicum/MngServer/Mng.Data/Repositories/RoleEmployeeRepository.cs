using Microsoft.EntityFrameworkCore;
using Mng.Core.Entities;
using Mng.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Data.Repositories
{
    public class RoleEmployeeRepository:IRoleEmployeeRepository
    {
        
        private readonly DataContext _dataContext;

        public RoleEmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<RoleEmployee>> GetAllAsync()
        {
            return await _dataContext.RolesEmployees.ToListAsync();
        }

        public async Task<RoleEmployee> GetByIdAsync(int roleEmployee)
        {
            return await _dataContext.RolesEmployees.FirstAsync(e => e.Id == roleEmployee);
        }

        public async Task<RoleEmployee> AddAsync(RoleEmployee roleEmployee)
        {
            _dataContext.RolesEmployees.Add(roleEmployee);
            await _dataContext.SaveChangesAsync();
            return roleEmployee;
        }

        public async Task<RoleEmployee> UpdateAsync(RoleEmployee roleEmployee)
        {
            var existRoleEmployee = await GetByIdAsync(roleEmployee.Id);
            _dataContext.Entry(existRoleEmployee).CurrentValues.SetValues(existRoleEmployee);
            await _dataContext.SaveChangesAsync();
            return existRoleEmployee;
        }

        public async Task DeleteAsync(int employeeRoleId)
        {
            var employeeRole = await GetByIdAsync(employeeRoleId);
            _dataContext.RolesEmployees.Remove(employeeRole);
            await _dataContext.SaveChangesAsync();
        }
    }
}
