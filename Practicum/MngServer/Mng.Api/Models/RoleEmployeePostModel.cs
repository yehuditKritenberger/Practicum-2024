using Mng.Core.Entities;

namespace Mng.Api.Models
{
    public class RoleEmployeePostModel
    {
        public int EmployeeId { get; set; }

        public Role Role { get; set; }

        public DateTime EntryDate { get; set; }

        public bool IsMangerialRole { get; set; }
    }
}
