using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mng.Core.Services;

namespace Mng.Api.Controllers
{
    public class roleEmployeeController : ControllerBase
    {
        private readonly IRoleEmployeeService _roleEmployeeService;
        private readonly IMapper _mapper;

        public roleEmployeeController(IRoleEmployeeService roleEmployeeService, IMapper mapper)
        {
            _roleEmployeeService = roleEmployeeService;
            _mapper = mapper;
        }


    }
}
