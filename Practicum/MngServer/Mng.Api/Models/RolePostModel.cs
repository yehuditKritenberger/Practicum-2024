using Mng.Core.Entities;

namespace Mng.Api.Models
{
    public class RolePostModel
    {
        public string Name { get; set; }

        public List<int> RoleEmployeesIds { get; set; }
    }
}
