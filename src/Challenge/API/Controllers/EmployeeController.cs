using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.DTOs;
using DAL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBLL employeeBLL;
        public EmployeeController(IEmployeeBLL employeeBLL)
        {
            this.employeeBLL = employeeBLL;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            EmployeeDTO employee;
            try
            {
                employee = await employeeBLL.GetEmployeeById(id);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await employeeBLL.GetEmployees();
            return Ok(employees);
        }
    }
}
