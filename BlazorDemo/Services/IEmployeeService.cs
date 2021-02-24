using BlazorDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees(int departmentId);

        Task<Employee> Fire(int id);

        Task Add(Employee employee);
    }
}
