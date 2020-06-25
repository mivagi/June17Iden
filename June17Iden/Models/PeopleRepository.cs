using June17Iden.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace June17Iden.Models
{
    public class PeopleRepository : IPeople
    {
        private readonly AppDbContent content;

        public PeopleRepository(AppDbContent content)
        {
            this.content = content;
        }
        public IEnumerable<Person> People => content.People;

        public void Create(Person person)
        {
            if(person.Id == 0)
            {
                content.People.Add(person);
            }
            else
            {
                Person pers = content.People.FirstOrDefault(p => p.Id == person.Id);
                pers.Name = person.Name;
                pers.Age = person.Age;
            }
            content.SaveChanges();
        }

        public void Delete(int id)
        {
            Person person = content.People.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                content.People.Remove(person);
                content.SaveChanges();
            }
            
        }
    }
}
