using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Repository.Interface;
using AjmeraPracticalAssessment.Service.Interface;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AjmeraPracticalAssessment.Service
{
    public class BookkeepingServiceRead : IBookkeepingServiceRead
    {
        #region Private Variable
        private IBookkeepingRepositoryRead bookkeepingRepositoryRead;
        #endregion

        #region Constructor
        public BookkeepingServiceRead(IBookkeepingRepositoryRead bookkeepingRepositoryRead)
        {
            this.bookkeepingRepositoryRead = bookkeepingRepositoryRead;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns all the books in book keeping DB
        /// </summary>
        /// <returns>List of BookkeeperRead object</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BookkeeperRead> GetAllBookDetails()
        {
            try
            {
                List<BookkeeperRead> repoResponse = bookkeepingRepositoryRead.GetAllBookDetails();
                repoResponse = FilterRepoResponse(repoResponse);
                return repoResponse;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Returns book details wrt to BookID
        /// </summary>
        /// <returns>BookkeeperRead object</returns>
        /// <exception cref="NotImplementedException"></exception>
        public BookkeeperRead GetBookDetailById(string id)
        {
            try
            {
                BookkeeperRead repoResponse = bookkeepingRepositoryRead.GetBookDetailById(id);
                repoResponse = FilterRepoResponse(repoResponse);
                return repoResponse;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Private Methods
        private List<BookkeeperRead> FilterRepoResponse(List<BookkeeperRead> repoResponse)
        {
            foreach (BookkeeperRead item in repoResponse)
            {
                if (string.IsNullOrEmpty(item.BookName))
                {
                    item.BookName = "NA";
                }
                if (string.IsNullOrEmpty(item.AuthorName))
                {
                    item.AuthorName = "NA";
                }
            }

            return repoResponse;
        }

        private BookkeeperRead FilterRepoResponse(BookkeeperRead repoResponse)
        {
            if (string.IsNullOrEmpty(repoResponse.BookName))
            {
                repoResponse.BookName = "NA";
            }
            if (string.IsNullOrEmpty(repoResponse.AuthorName))
            {
                repoResponse.AuthorName = "NA";
            }
            return repoResponse;
        }
        #endregion
    }
}
