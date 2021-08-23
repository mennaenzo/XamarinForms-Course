using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionViewDemo.Models
{
    public class CustomerGroup : List<Customer>
    {
        public string Name { get; set; }

        public CustomerGroup(string name, List<Customer> customers) : base(customers)
        {
            Name = name;
        }
    }
}
