using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Core.Entities
{
    public class RoleEmployee
    {
        
        public int Id { get; set; }
        
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        
        public int RoleId { get; set; }
        
        public Role Role { get; set; }

        public DateTime EntryDate { get; set; }

        public bool IsMangerialRole { get; set; }

    }
}
