using DAL.Entities;
using DAL.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public HttpClient httpClient { get; }
        public EmployeeRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/");
        }

        public async Task<ICollection<Employee>> GetAll()
        {
            var response = await httpClient.GetAsync("Employees");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};
            //var employees = JsonSerializer.Deserialize<ICollection<Employee>>(content, options);

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var employees =  JsonConvert.DeserializeObject<ICollection<Employee>>(content, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
            //var employees = JsonSerializer.Deserialize<ICollection<Employee>>(content);
            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
            var employess = await GetAll();

            var employee = employess.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                throw new EntityNotFoundException(string.Format("Entity with id {0} not found.", id));


            return employee;
        }

    }
}
