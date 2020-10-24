using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class HourlySalaryEnployeeDTO : EmployeeDTO
    {
        public double HourlySalary { get; set; }
        public HourlySalaryEnployeeDTO(int Id, string Name, string ContractTypeName, int RoleId, string RoleName, string RoleDesciption, double AnnualSalary, double HourlySalary)
            : base(Id, Name, ContractTypeName, RoleId, RoleName, RoleDesciption, AnnualSalary)
        {
            this.HourlySalary = HourlySalary;
        }
    }
}
