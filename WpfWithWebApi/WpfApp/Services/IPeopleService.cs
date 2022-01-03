using System.Collections.Generic;
using System.Threading.Tasks;

using WpfWithWebApi.Wpf.Models;

namespace WpfWithWebApi.Wpf.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetPeople();
    }
}