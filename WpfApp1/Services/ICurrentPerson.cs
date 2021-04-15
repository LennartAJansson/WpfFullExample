using WpfApp1.Models;

namespace WpfApp1.Services
{
    public delegate void PersonChangedDelegate(Person person);

    public interface ICurrentPerson
    {
        event PersonChangedDelegate PersonChanged;

        Person Person { get; set; }
    }
}