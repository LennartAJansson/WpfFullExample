
using WpfWithWebApi.Model;

namespace WpfWithWebApi.Wpf.Services
{
    public delegate void PersonChangedDelegate(Person person);

    public interface ICurrentPerson
    {
        event PersonChangedDelegate PersonChanged;

        Person Person { get; set; }
    }
}