namespace WpfWithWebApi.WebApi.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WpfWithWebApi.Model;

    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetPerson(int id);
    }
}