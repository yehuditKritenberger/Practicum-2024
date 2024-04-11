using Mng.Core.Entities;
using Mng.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.DTO
{
    public class EmployeeOutputDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TZ { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public DateTime BeginningOfWork { get; set; }

        public bool ActivityStatus { get; set; }

        public List<RoleEmployeeDTO> RolesEmployee { get; set; }
    }
}
