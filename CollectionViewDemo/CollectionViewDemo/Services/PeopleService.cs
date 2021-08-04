using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionViewDemo.Services
{
    public class PeopleService
    {
        public static List<Person> GetPeople()
        {
            var people = new Faker<Person>()
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .RuleFor(x => x.Email, f => f.Person.Email)
                .Generate(25);

            return people.ToList();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
