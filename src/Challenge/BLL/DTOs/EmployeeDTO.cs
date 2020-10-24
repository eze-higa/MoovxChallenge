using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public abstract class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double AnnualSalary { get; set; }

        public EmployeeDTO(int Id, string Name, string ContractTypeName, int RoleId, string RoleName, string RoleDesciption, double AnnualSalary)
        {
            this.Id = Id;
            this.Name = Name;
            this.ContractTypeName = ContractTypeName;
            this.RoleId = RoleId;
            this.RoleName = RoleName;
            this.RoleDescription = RoleDescription;
            this.AnnualSalary = AnnualSalary;
        }
    }
}
