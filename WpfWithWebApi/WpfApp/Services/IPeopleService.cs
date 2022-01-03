using System.Collections.Generic;
using System.Threading.Tasks;

using WpfWithWebApi.Model;

namespace WpfWithWebApi.Wpf.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task<Person> GetPersonAsync(int id);
    }
}