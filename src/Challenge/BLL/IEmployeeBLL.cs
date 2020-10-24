using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IEmployeeBLL
    {
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<ICollection<EmployeeDTO>> GetEmployees();
    }
}
