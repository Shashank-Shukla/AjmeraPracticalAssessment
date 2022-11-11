using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Contracts.Write;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraPracticalAssessment.Repository.Interface
{
    public interface IBookkeepingRepositoryWrite
    {
        Task<string> InsertBookDetails(BookkeeperWrite bookDetails);
        Task<bool> UpdateBookDetails(BookkeeperRead bookDetails);
        Task<bool> DeleteBookDetails(string id);
    }
}
