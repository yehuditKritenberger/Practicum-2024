using Mng.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mng.Data.DTO
{
    public class RoleEmployeeDTO
    {
        public int RoleId { get; set; }

        public DateTime EntryDate { get; set; }

        public bool IsMangerialRole { get; set; }
    }
}
