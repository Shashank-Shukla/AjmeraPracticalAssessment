using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraPracticalAssessment.HealthCheckAPI.Interface
{
    public interface ICheckDatabaseConnection
    {
        Task CheckDatabaseHealth(string connectionString, List<string> tableNames);
    }
}
