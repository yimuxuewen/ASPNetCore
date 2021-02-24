using GrpcDemo.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcDemo.Repository
{
    public class EmployeeSQLRepository : IEmployeeRepository
    {
        private readonly APPDbContext _appdbcontext;

        public EmployeeSQLRepository(APPDbContext appdbcontext)
        {
            _appdbcontext = appdbcontext;
        }
        public Task<Employee> Add(Employee employee)
        {
            //employee.Id = _appdbcontext.Employees.Count()>0 ? _appdbcontext.Employees.Max(x =>x.Id)+1:1;
            _appdbcontext.Employees.AddAsync(employee);
            _appdbcontext.SaveChanges();
            return Task.Run(()=> employee);
        }

        public Task<Employee> Fire(int id)
        {
            var employee = _appdbcontext.Employees.FirstOrDefault(x => x.Id == id);
            if (employee!=null)
            {
                employee.Fired = true;
            }
            var result = _appdbcontext.Employees.Attach(employee);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appdbcontext.SaveChanges();
            return Task.Run(() => employee);
        }

        public Task<IEnumerable<Employee>> GetEmployees(int departmentId)
        {
            var employees= _appdbcontext.Employees.ToList().FindAll(x => x.DepartmentId == departmentId);
            return Task.Run(()=> employees as IEnumerable<Employee>);
        }
    }
}
