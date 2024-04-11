using Mng.Core.Entities;
using Mng.Core.Repositories;
using Mng.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Mng.Service
{
    public class RoleEmployeeService : IRoleEmployeeService
    {
        private readonly IRoleEmployeeRepository _roleEmployeeRepository;

        public RoleEmployeeService(IRoleEmployeeRepository roleEmployeeRepository)
        {
            _roleEmployeeRepository = roleEmployeeRepository;
        }

        public async Task<IEnumerable<RoleEmployee>> GetAllAsync()
        {
            return await _roleEmployeeRepository.GetAllAsync();
        }

        public async Task<RoleEmployee> GetByIdAsync(int roleEmployeeIdeId)
        {
            return await _roleEmployeeRepository.GetByIdAsync(roleEmployeeIdeId);
        }

        public async Task<RoleEmployee> AddAsync(RoleEmployee roleEmployee)
        {
            return await _roleEmployeeRepository.AddAsync(roleEmployee);
        }

        public async Task<RoleEmployee> UpdateAsync(RoleEmployee roleEmployee)
        {
            return await _roleEmployeeRepository.UpdateAsync(roleEmployee);
        }

        public async Task DeleteAsync(int roleEmployeeId)
        {
            await _roleEmployeeRepository.DeleteAsync(roleEmployeeId);
        }
    }
}
