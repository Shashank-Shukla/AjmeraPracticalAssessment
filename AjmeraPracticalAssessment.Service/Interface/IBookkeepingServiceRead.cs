using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AjmeraPracticalAssessment.Contracts.Read;

namespace AjmeraPracticalAssessment.Service.Interface
{
    public interface IBookkeepingServiceRead
    {
        Task<BookkeeperRead> GetBookDetailById(string id);
        Task<List<BookkeeperRead>> GetAllBookDetails();
    }
}
