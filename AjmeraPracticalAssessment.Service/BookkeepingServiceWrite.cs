using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Contracts.Write;
using AjmeraPracticalAssessment.Repository;
using AjmeraPracticalAssessment.Repository.Interface;
using AjmeraPracticalAssessment.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AjmeraPracticalAssessment.Service
{
    public class BookkeepingServiceWrite : IBookkeepingServiceWrite
    {
        #region Private Variable
        private IBookkeepingRepositoryWrite bookkeepingRepositoryWrite;
        private IBookkeepingServiceRead bookkeepingServiceRead;
        #endregion

        #region Constructor
        public BookkeepingServiceWrite(IBookkeepingRepositoryWrite bookkeepingRepositoryWrite
                                     , IBookkeepingServiceRead bookkeepingServiceRead)
        {
            this.bookkeepingRepositoryWrite = bookkeepingRepositoryWrite;
            this.bookkeepingServiceRead = bookkeepingServiceRead;
        }
        #endregion

        #region Public Methods

        public async Task<string> InsertBookDetails(BookkeeperWrite bookDetails)
        {
            try
            {
                bookDetails = SanitizeInputs(bookDetails);
                string response = await bookkeepingRepositoryWrite.InsertBookDetails(bookDetails);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateBookDetails(string id, BookkeeperWrite bookDetails)
        {
            try
            {
                BookkeeperWrite readExistingData = await bookkeepingServiceRead.GetBookDetailById(id);
                bookDetails = readExistingData == null ? SanitizeInputs(bookDetails) : SanitizeInputs(bookDetails, readExistingData);
                // optimization: use mapping service to map 2 data models
                BookkeeperRead bookUpdate = new BookkeeperRead
                {
                    BookID = id,
                    BookName = bookDetails.BookName,
                    AuthorName = bookDetails.AuthorName,
                };
                bool response = await bookkeepingRepositoryWrite.UpdateBookDetails(bookUpdate);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteBookDetails(string id)
        {
            try
            {
                bool response = await bookkeepingRepositoryWrite.DeleteBookDetails(id);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Private Methods
        private BookkeeperWrite SanitizeInputs(BookkeeperWrite inputs, BookkeeperWrite readExistingData)
        {
            inputs.BookName = string.IsNullOrEmpty(inputs.BookName) ? readExistingData.BookName : inputs.BookName.Trim().Replace("--", "").Replace("=","").Replace("+","");
            inputs.AuthorName = string.IsNullOrEmpty(inputs.AuthorName) ? readExistingData.AuthorName : inputs.AuthorName.Trim().Replace("--", "").Replace("=", "").Replace("+", "");
            return inputs;
        }

        private BookkeeperWrite SanitizeInputs(BookkeeperWrite inputs)
        {
            inputs.BookName = string.IsNullOrEmpty(inputs.BookName) ? "NA" : inputs.BookName.Trim().Replace("--", "").Replace("=", "").Replace("+", "");
            inputs.AuthorName = string.IsNullOrEmpty(inputs.AuthorName) ? "NA" : inputs.AuthorName.Trim().Replace("--", "").Replace("=", "").Replace("+", "");
            return inputs;
        }
        #endregion
    }
}
