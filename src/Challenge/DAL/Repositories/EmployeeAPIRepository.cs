using DAL.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeAPIRepository : IRepository<EmployeeDTO>
    {
        public HttpClient httpClient { get; }

        public EmployeeAPIRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("http://localhost:54451/api/");
        }
        public async Task<ICollection<EmployeeDTO>> GetAll()
        {
            var response = await httpClient.GetAsync("employee");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            //var employees = JsonSerializer.Deserialize<ICollection<EmployeeDTO>>(content, options);
            var employees = JsonConvert.DeserializeObject<ICollection<EmployeeDTO>>(content);
            return employees;
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            var response = await httpClient.GetAsync(string.Format("employee/{0}", id));
            
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            
            var employee = JsonConvert.DeserializeObject<EmployeeDTO>(content); ;
            return employee;
        }
    }
}
