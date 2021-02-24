using GrpcDemo.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcDemo.Repository
{
    public class DepartmentSQLRepository : IDepartmentRepository
    {
        private readonly APPDbContext _appContext;

        public DepartmentSQLRepository(APPDbContext appContext)
        {
            _appContext = appContext;
        }
        public Task<Department> Add(Department department)
        {
            //department.Id = _appContext.Departments.Count()>0 ? _appContext.Departments.Max(x => x.Id) + 1:1;
            _appContext.Departments.Add(department);
            _appContext.SaveChanges();
            return Task.Run(() => department);
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(() => _appContext.Departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            var department = _appContext.Departments.FirstOrDefault(m => m.Id == id);
            return Task.Run(()=>department);
        }
    }
}
