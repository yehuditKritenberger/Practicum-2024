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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;

        public EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dataContext.Employees.Include(r => r.RolesEmployee).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _dataContext.Employees.Include(r => r.RolesEmployee).FirstOrDefaultAsync(r => r.Id == employeeId);
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            await _dataContext.Employees.AddAsync(employee);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            _dataContext.Employees.Update(employee);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employeeToDelete = _dataContext.Employees.FirstOrDefault(e => e.Id == employeeId);
            employeeToDelete.ActivityStatus = false;
            await _dataContext.SaveChangesAsync();
        }
    }
}
