using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class MonthlySalaryEmployeeDTO : EmployeeDTO
    {
        public double MothlySalary { get; set; }

        public MonthlySalaryEmployeeDTO(int Id, string Name, string ContractTypeName, int RoleId, string RoleName, string RoleDesciption, double AnnualSalary, double MothlySalary)
            : base(Id, Name, ContractTypeName, RoleId, RoleName, RoleDesciption, AnnualSalary)
        {
            this.MothlySalary = MothlySalary;
        }
    }
}
