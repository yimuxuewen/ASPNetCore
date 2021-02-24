using Grpc.Core;
using GrpcDemo.Protos;
using GrpcDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcDemo.GRpcServices
{
    public class DepartmentService : Departments.DepartmentsBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async override Task<GetAllDepartmentResponse> GetAllDepartments(GetAllDepartmentsRequest request, ServerCallContext context)
        {
            var result = new GetAllDepartmentResponse();
            var departments = await _departmentRepository.GetAll();
            result.Departments.AddRange(departments);

            return result;
        }

        public async override Task<AddDepartmentResoponse> AddDepartment(AddDepartmentRequest request, ServerCallContext context)
        {
            var department = await _departmentRepository.Add(request.Department);
            return new AddDepartmentResoponse()
            {
                Department = department
            };
        }
    }
}
