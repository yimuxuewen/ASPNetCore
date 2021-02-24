using GrpcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcDemo.Repository
{
    interface ISummaryRpository
    {

        Task<CompanySummary> GetCompanySummary();

    }
}
