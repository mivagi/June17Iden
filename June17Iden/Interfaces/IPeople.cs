using June17Iden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace June17Iden.Interfaces
{
    public interface IPeople
    {
        IEnumerable<Person> People { get; }
        void Create(Person person);
        void Delete(int id);
    }
}
