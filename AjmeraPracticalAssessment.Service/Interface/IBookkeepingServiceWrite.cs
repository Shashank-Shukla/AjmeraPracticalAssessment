using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Contracts.Write;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraPracticalAssessment.Service.Interface
{
    public interface IBookkeepingServiceWrite
    {
        Task<string> InsertBookDetails(BookkeeperWrite bookDetails);
        Task<bool> UpdateBookDetails(string id, BookkeeperWrite bookDetails);
        Task<bool> DeleteBookDetails(string id);
    }
}
