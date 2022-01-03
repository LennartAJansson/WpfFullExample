using System.Collections.Generic;
using System.Threading.Tasks;

using WpfWithWebApi.Wpf.Models;

namespace WpfWithWebApi.Wpf.Services
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
                    Ssn="EnterASSNHere",
                    Firstname="Firstname",
                    Lastname="Lastname",
                    Address="Address",
                    Postalcode="12345",
                    City="City",
                    Email="a@b.c",
                    Telephone="+4612345678"},
                new Person()
                {
                    Id=2,
                    Ssn="EnterASSNHere",
                    Firstname="FirstName",
                    Lastname="Lastname",
                    Address="Address",
                    Postalcode="12345",
                    City="City",
                    Email="a@b.c",
                    Telephone="+4612345678"}
            };
            return Task.FromResult(p);
        }
    }
}
