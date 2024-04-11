using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mng.Api.Models;
using Mng.Core.Entities;
using Mng.Core.Services;
using Mng.Data.DTO;

namespace Mng.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<RoleDTO>>(roles));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _roleService.GetByIdAsync(id);
            return Ok(_mapper.Map<RoleDTO>(product));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            await _roleService.AddAsync(role);
            return Ok(_mapper.Map<RoleDTO>(role));
        }
    }
}
