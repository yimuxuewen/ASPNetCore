using GrpcDemo.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcDemo.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees(int departmentId);

        Task<Employee> Fire(int id);

        Task<Employee> Add(Employee employee);
    }
}
