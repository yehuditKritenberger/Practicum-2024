using Mng.Core.Entities;
using Mng.Data.DTO;

namespace Mng.Api.Models
{
    public class EmployeePostModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TZ { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public DateTime BeginningOfWork { get; set; }

        public bool ActivityStatus { get; set; }

        public List<int> EmployeeRoles { get; set; }
    }
}
