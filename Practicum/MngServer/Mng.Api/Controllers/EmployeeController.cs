using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mng.Api.Models;
using Mng.Core.DTO;
using Mng.Core.Entities;
using Mng.Core.Services;
using Mng.Data.DTO;

namespace Mng.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var Employees = await _employeeService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeOutputDTO>>(Employees));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            return Ok(_mapper.Map<EmployeeOutputDTO>(employee));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeeInputDTO model)
        {
            var newEmployee = _mapper.Map<Employee>(model);
            await _employeeService.AddAsync(newEmployee);
            return Ok(_mapper.Map<EmployeeInputDTO>(newEmployee));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeeInputDTO model)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            _mapper.Map(model, employee);
            await _employeeService.UpdateAsync(employee);
            employee = await _employeeService.GetByIdAsync(id);
            return Ok(_mapper.Map<EmployeeInputDTO>(employee));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            await _employeeService.DeleteAsync(id);
            return Ok();
        }

    }
}
