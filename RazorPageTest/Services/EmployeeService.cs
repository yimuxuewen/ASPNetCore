﻿using RazorPageTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employees = new List<Employee>();
        public EmployeeService()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName = "小红",
                LastName = "李",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "小明",
                LastName = "张",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 2,
                FirstName = "小强",
                LastName = "王",
                Gender = Gender.男
            });
            _employees.Add(new Employee
            {
                Id = 4,
                DepartmentId = 2,
                FirstName = "小美",
                LastName = "陈",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 5,
                DepartmentId = 3,
                FirstName = "小希",
                LastName = "赵",
                Gender = Gender.女
            });
            _employees.Add(new Employee
            {
                Id = 6,
                DepartmentId = 3,
                FirstName = "小伟",
                LastName = "钱",
                Gender = Gender.男
            });
        }
        public Task Add(Employee employee)
        {
            employee.Id=_employees.Max(x=>x.Id)+1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Fire(int departmentId)
        {
            return Task.Run(() =>
            {
                var employee = _employees.FirstOrDefault(x => x.Id == departmentId);
                if (employee != null)
                {
                    employee.Fired = true;
                    return employee;
                }
                return null;
            });
        }

        public Task<IEnumerable<Employee>> GetEmployees(int departmentId)
        {
            return Task.Run(() =>  _employees.Where(x => x.DepartmentId == departmentId)) ;
        }
    }
}
