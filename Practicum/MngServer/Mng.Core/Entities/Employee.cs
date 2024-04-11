using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.Entities
{
    public class Employee
    {
        
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TZ { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }
        
        public DateTime BeginningOfWork { get; set; }

        public bool ActivityStatus { get; set; }

        public IEnumerable<RoleEmployee> RolesEmployee { get; set; }
    }
}
