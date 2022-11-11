using AjmeraPracticalAssessment.Contracts.Read;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraPracticalAssessment.Repository.Interface
{
    public interface IBookkeepingRepositoryRead
    {
        Task<List<BookkeeperRead>> GetAllBookDetails();
        Task<BookkeeperRead> GetBookDetailById(string id);
    }
}
