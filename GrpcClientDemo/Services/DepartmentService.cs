using GrpcDemo.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcClientDemo.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly Departments.DepartmentsClient _client;

        public DepartmentService(Departments.DepartmentsClient client)
        {
            _client = client;
        }

        public async Task Add(Department department)
        {
            await _client.AddDepartmentAsync(new AddDepartmentRequest()
            {
                Department = department
            }) ;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            var response =await _client.GetAllDepartmentsAsync(new GetAllDepartmentsRequest());
            return response.Departments ;
        }

    }
}
