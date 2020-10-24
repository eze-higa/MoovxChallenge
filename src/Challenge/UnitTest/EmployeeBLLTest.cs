using BLL;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class EmployeeBLLTest
    {
        [Fact]
        public async Task GetAll_EmployeeWithMonthlySalary_ShouldReturnCorrectCalculatedAnualSalary()
        {
            //Arrange
            var repository = new Mock<IRepository<Employee>>();
            var hourlySalaryEmployee = new Employee
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                HourlySalary = 60000,
                MonthlySalary = 80000
            };
            var monthlySalaryEmployee = new Employee
            {
                Id = 2,
                Name = "Sebastian",
                ContractTypeName = "MonthlySalaryEmployee",
                RoleId = 2,
                RoleName = "Contractor",
                HourlySalary = 60000,
                MonthlySalary = 80000
            };

            ICollection<Employee> employess = new List<Employee>
            {
                hourlySalaryEmployee,
                monthlySalaryEmployee
            };

            repository.Setup(repo => repo.GetAll())
                .Returns(Task.FromResult(employess));

            EmployeeBLL employeeBLL = new EmployeeBLL(repository.Object);

            //Act
            var employeesDTOs = await employeeBLL.GetEmployees();
            var monthlySalaryEmployees = employeesDTOs.Where(e => e.ContractTypeName == "MonthlySalaryEmployee");

            //Assert
            foreach (var employee in monthlySalaryEmployees)
            {
                Assert.True(employee is MonthlySalaryEmployeeDTO);
                Assert.Equal(CalculateAnnualSalaryForMonthlySalaryEmployee((employee as MonthlySalaryEmployeeDTO).MothlySalary), employee.AnnualSalary);
            }
        }


        public double CalculateAnnualSalaryForMonthlySalaryEmployee(double hourlySalary)
        {
            return hourlySalary * 12;
        }

        [Fact]
        public async Task GetAll_EmployeeWithHourlySalary_ShouldReturnCorrectCalculatedAnualSalary()
        {
            //Arrange
            var repository = new Mock<IRepository<Employee>>();
            var hourlySalaryEmployee = new Employee
            {
                Id = 1,
                Name = "Juan",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                HourlySalary = 60000,
                MonthlySalary = 80000
            };
            var monthlySalaryEmployee = new Employee
            {
                Id = 2,
                Name = "Sebastian",
                ContractTypeName = "MonthlySalaryEmployee",
                RoleId = 2,
                RoleName = "Contractor",
                HourlySalary = 60000,
                MonthlySalary = 80000
            };

            ICollection<Employee> employess = new List<Employee>
            {
                hourlySalaryEmployee,
                monthlySalaryEmployee
            };

            repository.Setup(repo => repo.GetAll())
                .Returns(Task.FromResult(employess));

            EmployeeBLL employeeBLL = new EmployeeBLL(repository.Object);

            //Act
            var employeesDTOs = await employeeBLL.GetEmployees();
            var hourlySalaryEmployees = employeesDTOs.Where(e => e.ContractTypeName == "HourlySalaryEmployee");

            //Assert
            foreach (var employee in hourlySalaryEmployees)
            {
                Assert.True(employee is HourlySalaryEnployeeDTO);
                Assert.Equal(CalculateAnnualSalaryForHourlySalaryEmployee((employee as HourlySalaryEnployeeDTO).HourlySalary), employee.AnnualSalary);
            }
        }
        public double CalculateAnnualSalaryForHourlySalaryEmployee(double hourlySalary)
        {
            return 120 * hourlySalary * 12;
        }

    }
}
