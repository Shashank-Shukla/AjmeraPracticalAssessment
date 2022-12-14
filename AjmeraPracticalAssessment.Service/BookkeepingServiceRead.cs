using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Contracts.Write;
using AjmeraPracticalAssessment.Repository.Interface;
using AjmeraPracticalAssessment.Service.Interface;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<BookkeeperRead>> GetAllBookDetails()
        {
            try
            {
                List<BookkeeperRead> repoResponse = await bookkeepingRepositoryRead.GetAllBookDetails();
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
        public async Task<BookkeeperWrite> GetBookDetailById(string id)
        {
            try
            {
                BookkeeperWrite repoResponse = await bookkeepingRepositoryRead.GetBookDetailById(id);
                if (repoResponse != null)
                {
                    repoResponse = FilterRepoResponse(repoResponse);
                }
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

        private BookkeeperWrite FilterRepoResponse(BookkeeperWrite repoResponse)
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
