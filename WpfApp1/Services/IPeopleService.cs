﻿using System.Collections.Generic;
using System.Threading.Tasks;

using WpfApp1.Models;

namespace WpfApp1.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<Person>> GetPeople();
    }
}