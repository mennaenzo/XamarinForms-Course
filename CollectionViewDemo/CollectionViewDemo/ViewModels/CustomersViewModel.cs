﻿using Bogus;
using CollectionViewDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CollectionViewDemo.ViewModels
{
    public class CustomersViewModel
    {
        public List<CustomerGroup> Customers { get; set; }

        public CustomersViewModel()
        {
            var customers = new Faker<Customer>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber())
                .Generate(50);

            var grouped = from c in customers
                          orderby c.Name
                          group c by c.Name[0].ToString()
                          into groups
                          select new CustomerGroup(groups.Key, groups.ToList());

            Customers = new List<CustomerGroup>(grouped);
        }
    }
}