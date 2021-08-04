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

        public ObservableCollection<Person> People { get; set; }

        public Person SelectedPerson
        {
            get => selectedPerson; 
            set
            {
                selectedPerson = value;
            }
        }

        public ICommand PersonChangedCommand { get; set; }

        public PeoplePageViewModel()
        {
            var people = PeopleService.GetPeople();

            People = new ObservableCollection<Person>(people);

            PersonChangedCommand = new Command(() =>
            {
                var i = 0;
            });
        }
    }
}
