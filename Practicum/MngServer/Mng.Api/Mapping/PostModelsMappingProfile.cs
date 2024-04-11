using AutoMapper;
using Mng.Api.Models;
using Mng.Core.Entities;

namespace Mng.Api.Mapping
{
    public class PostModelsMappingProfile : Profile
    {
        public PostModelsMappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>();
            CreateMap<RolePostModel, Role>();

        }
    }
}
