using GrpcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcDemo.Repository
{
    public class SummaryRpository : ISummaryRpository
    {
        private readonly IDepartmentRepository _departmentrepository;

        public SummaryRpository(IDepartmentRepository departmentrepository)
        {
            _departmentrepository = departmentrepository;
        }
        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(() =>
            {
                var all =_departmentrepository.GetAll().GetAwaiter().GetResult();
                return new CompanySummary
                {
                    EmployeeCount = all.Sum(x => x.EmployeeCount),
                    AverageDepartmentEmployeeCount = (int)(all.Average(x => x.EmployeeCount))
                };
            });
        }

    }
}
