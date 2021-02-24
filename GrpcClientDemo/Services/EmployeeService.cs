using GrpcDemo.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcClientDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Employees.EmployeesClient _client;
        public EmployeeService(Employees.EmployeesClient client)
        {
            _client = client;
        }
        public async Task Add(Employee employee)
        {
            await _client.AddEmployeeAsync(new AddEmployeeRequest()
            {
                Employee = employee
            });
        }

        public async Task<Employee> Fire(int departmentId)
        {
            var person = await _client.FireEmployeeAsync(new FireEmployeeRequest()
            {
                Id = departmentId
            });
            return person.Employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees(int departmentId)
        {
            var response = await _client.GetEmployeeesByIdAsync(new GetEmployeeesByIdRequest()
            {
                DepartmentId = departmentId
            });
            return response.Employee;
        }
    }
}
