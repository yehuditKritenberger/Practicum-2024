using Mng.Core.Entities;
using Mng.Core.Repositories;
using Mng.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public Task<Role> GetByIdAsync(int roleId)
        {
            return _roleRepository.GetByIdAsync(roleId);
        }

        public async Task<Role> AddAsync(Role role)
        {
            return await _roleRepository.AddAsync(role);
        }

        public Task<Role> UpdateAsync(Role role)
        {
            return _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(int rolrId)
        {
            await _roleRepository.DeleteAsync(rolrId);
        }

    }
}
