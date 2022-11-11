using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Contracts.Write;

namespace AjmeraPracticalAssessment.Service.Interface
{
    public interface IBookkeepingServiceRead
    {
        Task<BookkeeperWrite> GetBookDetailById(string id);
        Task<List<BookkeeperRead>> GetAllBookDetails();
    }
}
