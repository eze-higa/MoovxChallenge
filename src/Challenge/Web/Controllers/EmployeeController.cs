using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DTOs;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IRepository<EmployeeDTO> employeeAPIRepository;
        private readonly ILogger<EmployeeController> logger;
        public EmployeeController(ILogger<EmployeeController> logger, IRepository<EmployeeDTO> employeeAPIRepository)
        {
            this.logger = logger;
            this.employeeAPIRepository = employeeAPIRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            ICollection<EmployeeDTO> employees = new List<EmployeeDTO>();
            if (id == 0)
            {
                employees = await employeeAPIRepository.GetAll();
            }
            else
            {
                var employee = await employeeAPIRepository.GetById(id);
                if (employee != null)
                    employees.Add(employee);
            }

            return View(employees);
        }
    }
}