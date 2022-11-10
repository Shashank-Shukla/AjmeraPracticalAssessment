using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AjmeraPracticalAssessment.Service
{
    public class BookkeepingServiceRead : IBookkeepingServiceRead
    {
        /// <summary>
        /// Returns all the books in book keeping DB
        /// </summary>
        /// <returns>List of BookkeeperRead object</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BookkeeperRead> GetAllBookDetails()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            finally 
            {
                //
            }
            return new List<BookkeeperRead>();
        }

        /// <summary>
        /// Returns book details wrt to BookID
        /// </summary>
        /// <returns>BookkeeperRead object</returns>
        /// <exception cref="NotImplementedException"></exception>
        public BookkeeperRead GetBookDetailById()
        {
            try
            {
                return new BookkeeperRead();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
