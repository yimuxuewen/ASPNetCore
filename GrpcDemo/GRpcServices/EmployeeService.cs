using Grpc.Core;
using GrpcDemo.Protos;
using GrpcDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcDemo.GRpcServices
{
    public class EmployeeService:Employees.EmployeesBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async override Task<GetEmployeeesByIdResponse> GetEmployeeesById(GetEmployeeesByIdRequest request, ServerCallContext context)
        {
            var result = new GetEmployeeesByIdResponse();
            var employees =await _employeeRepository.GetEmployees(request.DepartmentId);
            result.Employee.AddRange(employees);
            return result;
        }

        public override async Task<AddEmployeeResponse> AddEmployee(AddEmployeeRequest request, ServerCallContext context)
        {
            var reslut=new AddEmployeeResponse();
            var employee =await _employeeRepository.Add(request.Employee);

            reslut.Employee = employee;

            return reslut;
        }

        public override async Task<FireEmployeeResponse> FireEmployee(FireEmployeeRequest request, ServerCallContext context)
        {
            var result=new FireEmployeeResponse();
            var employee= await _employeeRepository.Fire(request.Id);
            result.Employee = employee;
            return result;
        }
    }
}
