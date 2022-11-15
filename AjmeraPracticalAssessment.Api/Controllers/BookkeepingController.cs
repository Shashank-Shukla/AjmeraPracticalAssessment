using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Contracts.ReturnObject;
using AjmeraPracticalAssessment.Contracts.Write;
using AjmeraPracticalAssessment.HealthCheckAPI.Interface;
using AjmeraPracticalAssessment.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AjmeraPracticalAssessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookkeepingController : ControllerBase
    {

        #region Private variables
        private IBookkeepingServiceRead bookkeepingServiceRead;
        private IBookkeepingServiceWrite bookkeepingServiceWrite;
        private readonly ILogger<BookkeepingController> logger;
        private const string connectionStringName = "conn";
        #endregion

        #region Constructor
        public BookkeepingController(IBookkeepingServiceRead bookkeepingServiceRead, 
                                    IBookkeepingServiceWrite bookkeepingServiceWrite,
                                    ICheckDatabaseConnection checkDatabaseConnection,
                                    ILogger<BookkeepingController> logger,
                                    IConfiguration configuration)
        {
            this.bookkeepingServiceRead = bookkeepingServiceRead;
            this.bookkeepingServiceWrite = bookkeepingServiceWrite;
            this.logger = logger;
            checkDatabaseConnection.CheckDatabaseHealth(configuration.GetConnectionString(connectionStringName),
                                                        configuration.GetSection("HealthChecks:TableNames").Value.Split(',').ToList());
        }
        #endregion

        #region GET Methods
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                List<BookkeeperRead> bookkeeperReads= await bookkeepingServiceRead.GetAllBookDetails();
                logger.LogDebug($"{nameof(GetAllBooks)} Ok");
                return Ok(new ControllerResponse
                {
                    Success = true,
                    StatusCode = Ok().StatusCode,
                    ResponseObject = bookkeeperReads
                });
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ControllerResponse
                {
                    Success = false,
                    StatusCode = BadRequest().StatusCode,
                    ErrorMessage = ex.Message,
                    ResponseObject = null
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByID(string id)
        {
            try
            {
                BookkeeperWrite bookkeeperReads = await bookkeepingServiceRead.GetBookDetailById(id);
                if (bookkeeperReads == null)
                {
                    logger.LogDebug($"{nameof(GetBookByID)}: Object not found for id = {id}");
                    return NotFound(new ControllerResponse
                    {
                        Success = false,
                        StatusCode = NotFound().StatusCode,
                        ErrorMessage = $"{id} not found",
                        ResponseObject = bookkeeperReads
                    });
                }
                logger.LogDebug($"{nameof(GetBookByID)} Ok");
                return Ok(new ControllerResponse
                {
                    Success = true,
                    StatusCode = Ok().StatusCode,
                    ResponseObject = bookkeeperReads
                });
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ControllerResponse
                {
                    Success = false,
                    StatusCode = BadRequest().StatusCode,
                    ErrorMessage = ex.Message,
                    ResponseObject = null
                });
            }
        }
        #endregion


        #region POST Method
        [HttpPost]
        public async Task<IActionResult> InsertBookDetails([FromBody] BookkeeperWrite bookInput)
        {
            try
            {
                string responseID = await bookkeepingServiceWrite.InsertBookDetails(bookInput);
                logger.LogDebug($"{nameof(InsertBookDetails)} Ok");
                return Ok(new ControllerResponse
                {
                    Success = true,
                    StatusCode = Ok().StatusCode,
                    ResponseObject = responseID
                });
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ControllerResponse
                {
                    Success = false,
                    StatusCode = BadRequest().StatusCode,
                    ErrorMessage = ex.Message,
                    ResponseObject = null
                });
            }
        }
        #endregion


        #region PUT Method
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookDetail(string id, [FromBody] BookkeeperWrite bookInput)
        {
            string res = "Update failed!";
            try
            {
                bool response = await bookkeepingServiceWrite.UpdateBookDetails(id, bookInput);
                if (response) 
                {
                    res = "Update Successful!";
                }
                logger.LogDebug($"{nameof(UpdateBookDetail)} Ok");
                return Ok(new ControllerResponse
                {
                    Success = true,
                    StatusCode = Ok().StatusCode,
                    ResponseObject = res
                });
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(new ControllerResponse
                {
                    Success = false,
                    StatusCode = BadRequest().StatusCode,
                    ErrorMessage = ex.Message,
                    ResponseObject = res
                });
            }
        }
        #endregion


        #region DELETE Method
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookByID(string id)
        {
            string res = "Delete failed!";
            try
            {
                bool response = await bookkeepingServiceWrite.DeleteBookDetails(id);
                if (response)
                {
                    res = "Delete Successful!";
                }
                logger.LogDebug($"{nameof(DeleteBookByID)} Ok");
                return Ok(new ControllerResponse
                {
                    Success = true,
                    StatusCode = Ok().StatusCode,
                    ResponseObject = res
                });
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex.Message );
                return BadRequest(new ControllerResponse
                {
                    Success = false,
                    StatusCode = BadRequest().StatusCode,
                    ErrorMessage = ex.Message,
                    ResponseObject = res
                });
            }
        }
        #endregion
    }
}
