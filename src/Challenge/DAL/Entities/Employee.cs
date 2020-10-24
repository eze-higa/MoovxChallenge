using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Employee : EmployeeBase
    {
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }
    }
}
