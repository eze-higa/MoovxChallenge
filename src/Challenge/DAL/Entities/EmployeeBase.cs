using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public abstract class EmployeeBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }
}
