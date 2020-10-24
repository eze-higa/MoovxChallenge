using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTOs
{
    public class EmployeeDTO : EmployeeBase
    {
        public double AnnualSalary { get; set; }
    }
}
