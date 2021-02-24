using GrpcDemo.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcClientDemo.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();

        //Task<Department> GetById(int id);

        Task Add(Department department);

    }
}
