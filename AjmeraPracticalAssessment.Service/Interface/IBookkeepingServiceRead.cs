using System;
using System.Collections.Generic;
using System.Text;
using AjmeraPracticalAssessment.Contracts.Read;

namespace AjmeraPracticalAssessment.Service.Interface
{
    public interface IBookkeepingServiceRead
    {
        BookkeeperRead GetBookDetailById();
        List<BookkeeperRead> GetAllBookDetails();
    }
}
