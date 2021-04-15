using System.Collections.Generic;
using System.Threading.Tasks;

using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class PeopleService : IPeopleService
    {
        public Task<IEnumerable<Person>> GetPeople()
        {
            IEnumerable<Person> p = new List<Person>
            {
                new Person()
                {
                    Id=1,
                    Ssn="196101231451",
                    Firstname="Lennart",
                    Lastname="Jansson",
                    Address="Klockaregatan 2a",
                    Postalcode="25200",
                    City="Helsingborg",
                    Email="lennart.jansson@nexergroup.com",
                    Telephone="+46734400114"},
                new Person()
                {
                    Id=2,
                    Ssn="200111234076",
                    Firstname="Adam",
                    Lastname="Häggström",
                    Address="Nordanväg 6c",
                    Postalcode="24438",
                    City="Kävlinge",
                    Email="adh01@hotmail.se",
                    Telephone="+46723080868"}
            };
            return Task.FromResult(p);
        }
    }
}