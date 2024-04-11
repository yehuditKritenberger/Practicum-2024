using Mng.Core.Entities;
using Mng.Core.Repositories;
using Mng.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mng.Service
{
    public class EmployeeService : IEmployeeService
    {
        
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public (bool IsValid, string ErrorMessage) IsEmployeeValid(Employee employee)
        {
           
            if (!Regex.IsMatch(employee.TZ, @"^\d{9}$"))
            {
                return (false, "Invalid ID number");
            }

            if (employee.DateOfBirth < DateTime.Today.AddYears(-70))
            {
                return (false, "Employee cannot be older than 70 years old");
            }

            if (employee.BeginningOfWork < employee.DateOfBirth.AddYears(18))
            {
                return (false, "Employee cannot be younger than 18 years old");
            }

            if (employee.RolesEmployee != null && employee.RolesEmployee.Count() > 1)
            {
                foreach (RoleEmployee role in employee.RolesEmployee)
                {
                    if (role.EntryDate < employee.BeginningOfWork)
                    {
                        return (false, "Date of entry into work cannot be before start date");
                    }
                }

                foreach (var role1 in employee.RolesEmployee)
                {
                    foreach (var role2 in employee.RolesEmployee)
                    {
                        if (role1.RoleId == role2.RoleId && !object.ReferenceEquals(role1, role2))
                        {
                            return (false, "Cannot add the same role to an employee twice");
                        }
                    }
                }
            }

            return (true, null);
        }



        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _employeeRepository.GetByIdAsync(employeeId);
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            var validationResult = IsEmployeeValid(employee);

            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ErrorMessage);
            }

            return await _employeeRepository.AddAsync(employee);
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            var validationResult = IsEmployeeValid(employee);

            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.ErrorMessage);
            }

            return await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int employeeId)
        {
            await _employeeRepository.DeleteAsync(employeeId);
        }

    }
}
