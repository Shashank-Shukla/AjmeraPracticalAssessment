using System;
using System.Collections.Generic;
using System.Text;
using AjmeraPracticalAssessment.Contracts.Read;

namespace AjmeraPracticalAssessment.Service.Interface
{
    public interface IBookkeepingServiceRead
    {
        public BookkeeperRead GetBookDetailById();
        public BookkeeperRead GetAllBookDetails();
    }
}
