using System.Collections.Generic;
using System.Threading.Tasks;

using WpfWithWebApi.Model;

namespace WpfWithWebApi.Wpf.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();

        Task<Person> GetPersonAsync(object id);
    }
}