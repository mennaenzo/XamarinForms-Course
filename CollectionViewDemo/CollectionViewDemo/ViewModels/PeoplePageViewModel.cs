using CollectionViewDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewDemo.ViewModels
{
    public class PeoplePageViewModel : INotifyPropertyChanged
    {
        private Person selectedPerson;
        private List<object> selectedPeople;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Person> People { get; set; }

        public Person SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public List<object> SelectedPeople
        {
            get => selectedPeople; 
            set
            {
                selectedPeople = value;
                OnPropertyChanged();
            }
        }

        public ICommand PersonChangedCommand { get; set; }
        public ICommand PeopleChangedCommand { get; set; }
        public ICommand ClearCommand { get; set; }


        public PeoplePageViewModel()
        {
            var people = PeopleService.GetPeople();

            People = new ObservableCollection<Person>(people);

            SelectedPeople = new List<object>(People.Take(5));

            SelectedPerson = People.Skip(3).Take(1).FirstOrDefault();

            PersonChangedCommand = new Command((p) =>
            {
                var perdon = p;
            });

            PeopleChangedCommand = new Command((p) =>
            {
                var peopleList = p;
            });

            ClearCommand = new Command(() =>
            {
                SelectedPeople = null;
            });
        }


    }
}
