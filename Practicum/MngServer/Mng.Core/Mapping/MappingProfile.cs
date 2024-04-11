using AutoMapper;
using Mng.Core.DTO;
using Mng.Core.Entities;
using Mng.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeInputDTO>().ReverseMap();
            CreateMap<Employee, EmployeeOutputDTO>().ReverseMap();
            CreateMap<RoleEmployee, RoleEmployeeDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
