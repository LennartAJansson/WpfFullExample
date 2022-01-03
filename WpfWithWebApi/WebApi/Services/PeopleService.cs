namespace WpfWithWebApi.WebApi.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using WpfWithWebApi.Model;

    public class PeopleService : IPeopleService
    {
        private readonly IEnumerable<Person> people = new List<Person>
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

        public Task<IEnumerable<Person>> GetPeople() => Task.FromResult(people);
        public Task<Person> GetPerson(int id) => Task.FromResult(people.SingleOrDefault(p => p.Id == id));
    }
}
