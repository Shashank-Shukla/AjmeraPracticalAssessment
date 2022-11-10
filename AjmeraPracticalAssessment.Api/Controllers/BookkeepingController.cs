using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
