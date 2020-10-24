using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBLL : IEmployeeBLL
    {
        private readonly IRepository<Employee> employeeRepository;

        public EmployeeBLL(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            var employee = await employeeRepository.GetById(id);
            return GetEmployeeDTO(employee);
        }

        public async Task<ICollection<EmployeeDTO>> GetEmployees()
        {
            var employees = await employeeRepository.GetAll();
            List<EmployeeDTO> employeesDTO = new List<EmployeeDTO>();

            foreach (var employee in employees)
            {
                employeesDTO.Add(GetEmployeeDTO(employee));
            }

            return employeesDTO;
        }
        private EmployeeDTO GetEmployeeDTO(Employee employee)
        {
            EmployeeDTO employeeDTO;

            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    employeeDTO = GetHourlySalaryEmployeeDTO(employee);
                    break;
                default:
                    employeeDTO = GetMonthlySalaryEmployeeDTO(employee);
                    break;
            }

            return employeeDTO;
        }
        private HourlySalaryEnployeeDTO GetHourlySalaryEmployeeDTO(Employee employee)
        {
            var annualSalary = GetAnnualSalaryForHourlyContract(employee.HourlySalary);
            return new HourlySalaryEnployeeDTO(employee.Id, employee.Name, employee.ContractTypeName, employee.RoleId, employee.RoleName, employee.RoleDescription, annualSalary, employee.HourlySalary);
        }
        private double GetAnnualSalaryForHourlyContract(double salary)
        {
            return 120 * salary * 12;
        }
        public MonthlySalaryEmployeeDTO GetMonthlySalaryEmployeeDTO(Employee employee)
        {
            var annualSalary = GetAnnualSalaryForMonthlyContract(employee.MonthlySalary);
            return new MonthlySalaryEmployeeDTO(employee.Id, employee.Name, employee.ContractTypeName, employee.RoleId, employee.RoleName, employee.RoleDescription, annualSalary, employee.MonthlySalary);
        }
        private double GetAnnualSalaryForMonthlyContract(double salary)
        {
            return salary * 12;
        }
    }
}
