using CollectionViewDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewDemo.ViewModels
{
    public class PeoplePageViewModel
    {
        private Person selectedPerson;
        private List<object> selectedPeople;

        public ObservableCollection<Person> People { get; set; }

        public Person SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
            }
        }

        public List<object> SelectedPeople
        {
            get => selectedPeople; 
            set
            {
                selectedPeople = value;
            }
        }

        public ICommand PersonChangedCommand { get; set; }
        public ICommand PeopleChangedCommand { get; set; }


        public PeoplePageViewModel()
        {
            var people = PeopleService.GetPeople();

            People = new ObservableCollection<Person>(people);

            SelectedPeople = new List<object>();

            PersonChangedCommand = new Command((p) =>
            {
                var perdon = p;
            });

            PeopleChangedCommand = new Command((p) =>
            {
                var peopleList = p;
            });
        }


    }
}
