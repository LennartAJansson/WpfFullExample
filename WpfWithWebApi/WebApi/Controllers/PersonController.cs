using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

using WpfWithWebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WpfWithWebApi.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            List<Person> lst = new()
            {
                new Person { Id = 1, Name = "Adam" },
                new Person { Id = 2, Name = "Bertil" },
                new Person { Id = 3, Name = "Caesar" }
            };
            return lst.Select(a => a);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return new Person { Id = id, Name = "Adam" };
        }

        //TODO Define Post method in api
        // POST api/<PersonController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //TODO Define Put method in api
        // PUT api/<PersonController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //TODO Define Delete method in api
        // DELETE api/<PersonController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}