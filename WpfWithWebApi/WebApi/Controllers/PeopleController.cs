using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WpfWithWebApi.Model;
using WpfWithWebApi.WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WpfWithWebApi.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> logger;
        private readonly IPeopleService peopleService;

        public PeopleController(ILogger<PeopleController> logger, IPeopleService peopleService)
        {
            this.logger = logger;
            this.peopleService = peopleService;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IEnumerable<Person>> GetAsync() => await peopleService.GetPeople();

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<Person> GetAsync(int id) => await peopleService.GetPerson(id);

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