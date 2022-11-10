using AjmeraPracticalAssessment.Contracts.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace AjmeraPracticalAssessment.Repository.Interface
{
    public interface IBookkeepingRepositoryRead
    {
        List<BookkeeperRead> GetAllBookDetails();
        BookkeeperRead GetBookDetailById();
    }
}
