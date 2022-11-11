using AjmeraPracticalAssessment.Contracts.Read;
using AjmeraPracticalAssessment.Contracts.ReturnObject;
using AjmeraPracticalAssessment.HealthCheckAPI.Interface;
using AjmeraPracticalAssessment.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjmeraPracticalAssessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookkeepingController : ControllerBase
    {
        //// GET: api/<BookkeepingController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<BookkeepingController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<BookkeepingController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BookkeepingController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BookkeepingController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        #region Private variables
        //private ControllerResponse controllerResponse = null;
        private IBookkeepingServiceRead bookkeepingServiceRead;
        private IBookkeepingServiceWrite bookkeepingServiceWrite;
        private const string connectionStringName = "conn";
        #endregion

        #region Constructor
        public BookkeepingController(IBookkeepingServiceRead bookkeepingServiceRead, 
                                    IBookkeepingServiceWrite bookkeepingServiceWrite,
                                    ICheckDatabaseConnection checkDatabaseConnection,
                                    IConfiguration configuration)
        {
            this.bookkeepingServiceRead = bookkeepingServiceRead;
            this.bookkeepingServiceWrite = bookkeepingServiceWrite;
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

                return Ok(new ControllerResponse
                {
                    Success = true,
                    StatusCode = Ok().StatusCode,
                    ResponseObject = bookkeeperReads
                });
            }
            catch (System.Exception ex)
            {
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
                BookkeeperRead bookkeeperReads = await bookkeepingServiceRead.GetBookDetailById(id);

                return Ok(new ControllerResponse
                {
                    Success = true,
                    StatusCode = Ok().StatusCode,
                    ResponseObject = bookkeeperReads
                });
            }
            catch (System.Exception ex)
            {
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
        public async Task<IActionResult> InsertBookDetails()
        {
            try
            {
                return Ok();
            }
            catch (System.Exception ex)
            {
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
        [HttpPut]
        public async Task<IActionResult> UpdateBookDetail()
        {
            try
            {
                return Ok();
            }
            catch (System.Exception ex)
            {
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


        #region DELETE Method
        [HttpDelete]
        public async Task<IActionResult> DeleteBookByID()
        {
            try
            {
                return Ok();
            }
            catch (System.Exception ex)
            {
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
    }
}
