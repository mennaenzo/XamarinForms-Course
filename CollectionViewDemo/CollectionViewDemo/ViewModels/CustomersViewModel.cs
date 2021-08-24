using Bogus;
using CollectionViewDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectionViewDemo.ViewModels
{
    public class CustomersViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CustomerGroup> customers;
        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy; 
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CustomerGroup> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public CustomersViewModel()
        {
            Customers = new ObservableCollection<CustomerGroup>();
            var group = new CustomerGroup("", new List<Customer>());

            for (int i = 0; i < 10; i++)
            {
                group.Add(new Customer
                {
                    Id = 0,
                    Name = "",
                    Phone = ""
                });
            }

            Customers.Add(group);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task GetData()
        {
            IsBusy = true;

            await Task.Delay(5000);

            var customers = new Faker<Customer>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber())
                .Generate(50);

            var grouped = from c in customers
                          orderby c.Name
                          group c by c.Name[0].ToString()
                          into groups
                          select new CustomerGroup(groups.Key, groups.ToList());

            int id = 0;
            foreach (var group in grouped)
            {
                foreach (var item in group)
                {
                    item.Id = id;
                    id++;
                }
            }

            Customers = new ObservableCollection<CustomerGroup>(grouped);

            Customers.Add(new CustomerGroup("Empty", new List<Customer>()));

            IsBusy = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
