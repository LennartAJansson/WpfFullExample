using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class CurrentPerson : ICurrentPerson
    {
        public event PersonChangedDelegate PersonChanged;

        public Person Person
        {
            get => person;
            set
            {
                person = value;
                PersonChanged?.Invoke(value);
            }
        }

        private Person person;

        public CurrentPerson()
        {
        }
    }
}