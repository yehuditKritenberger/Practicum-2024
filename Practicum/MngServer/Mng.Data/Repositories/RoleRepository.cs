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
    public class RoleRepository:IRoleRepository
    {
        private readonly DataContext _dataContext;

        public RoleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _dataContext.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int roleId)
        {
            return await _dataContext.Roles.Include(r => r.RolesEmployees).FirstAsync(r => r.Id == roleId);
        }

        public async Task<Role> AddAsync(Role role)
        {
            _dataContext.Roles.Add(role);
            await _dataContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            var existPRole = await GetByIdAsync(role.Id);
            _dataContext.Entry(existPRole).CurrentValues.SetValues(role);
            await _dataContext.SaveChangesAsync();
            return role;//TODO check which product to return!
        }

        public async Task DeleteAsync(int roleId)
        {
            var product = await GetByIdAsync(roleId);
            _dataContext.Roles.Remove(product);
            await _dataContext.SaveChangesAsync();
        }

    }
}
