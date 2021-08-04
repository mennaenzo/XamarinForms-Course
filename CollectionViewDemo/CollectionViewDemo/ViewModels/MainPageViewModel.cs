using CollectionViewDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewDemo.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool isRefreshing;
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get => products; 
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteCommand { get; set; }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand ThresholdReachedCommand { get; set; }
        
        public MainPageViewModel()
        {
            Products = new ObservableCollection<Product>();

            RefreshItems();

            DeleteCommand = new Command((item) =>
            {
                Products.Remove((Product)item);
            });

            RefreshCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await Task.Delay(3000);
                RefreshItems();
                IsRefreshing = false;
            });

            ThresholdReachedCommand = new Command(async () =>
            {
                RefreshItems(Products.Count);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RefreshItems(int lastIndex = 0)
        {
            int numberOfItemsPerPage = 10;
            var items = new ObservableCollection<Product>
            {
                new Product
                {
                    Name = "Yogurt",
                    Price = 60.0m,
                    Image = "yogurt.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Watermelon",
                    Price = 30.0m,
                    Image = "watermelon.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Water Bottle",
                    Price = 80.0m,
                    Image = "water_bottle.png",
                    HasOffer = true,
                    OfferPrice = 69.99m
                },
                new Product
                {
                    Name = "Tomato",
                    Price = 120.0m,
                    Image = "tomato.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Tea",
                    Price = 65.0m,
                    Image = "tea_bag.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Sparkling Drink",
                    Price = 35.0m,
                    Image = "sparkling_drink.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Spaguetti",
                    Price = 15.0m,
                    Image = "spaguetti.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Cream",
                    Price = 48.0m,
                    Image = "cream.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Snack",
                    Price = 25.0m,
                    Image = "009_snack.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Shrimp",
                    Price = 300.0m,
                    Image = "shrimp.png",
                    HasOffer = true,
                    OfferPrice = 250.0m
                },
                new Product
                {
                    Name = "Seasoning",
                    Price = 185.0m,
                    Image = "seasoning.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Sauce",
                    Price = 220.0m,
                    Image = "sauce.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Rice",
                    Price = 48.0m,
                    Image = "rice.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Peas",
                    Price = 114.0m,
                    Image = "peas.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Ham",
                    Price = 215.0m,
                    Image = "ham_1.png",
                    HasOffer = true,
                    OfferPrice = 189.0m
                },
                new Product
                {
                    Name = "Chicken Leg",
                    Price = 142.0m,
                    Image = "chicken_leg.png",
                    HasOffer = true,
                    OfferPrice = 125.0m
                },
                new Product
                {
                    Name = "Pizza",
                    Price = 321.0m,
                    Image = "pizza.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Pineapple",
                    Price = 49.0m,
                    Image = "pineapple.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Pepper",
                    Price = 60.0m,
                    Image = "pepper.png",
                    HasOffer = true,
                    OfferPrice = 30.0m
                },
                new Product
                {
                    Name = "Pasta",
                    Price = 52.0m,
                    Image = "pasta.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Oil Bottle",
                    Price = 152.0m,
                    Image = "oil_bottle",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Mushroom",
                    Price = 28.0m,
                    Image = "mushroom.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Milk Bottle",
                    Price = 85.0m,
                    Image = "milk_bottle.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Meat",
                    Price = 450.0m,
                    Image = "meat.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Lemon",
                    Price = 20.0m,
                    Image = "lemon.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Tomato Sauce",
                    Price = 15.0m,
                    Image = "tomato_sauce.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Juice",
                    Price = 60.0m,
                    Image = "juice.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Ice Cream",
                    Price = 251.0m,
                    Image = "ice_cream.png",
                    HasOffer = true,
                    OfferPrice = 200.0m
                },
                new Product
                {
                    Name = "Ham",
                    Price = 290.0m,
                    Image = "ham.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Ice",
                    Price = 125.0m,
                    Image = "ice.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Flour",
                    Price = 86.0m,
                    Image = "flour.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Fish",
                    Price = 440.0m,
                    Image = "fish_1.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Fish 2",
                    Price = 425.0m,
                    Image = "fish.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Eggs",
                    Price = 150.0m,
                    Image = "eggs.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Cucumber",
                    Price = 35.0m,
                    Image = "cucumber.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Croissant",
                    Price = 68.0m,
                    Image = "croissant.png",
                    HasOffer = true,
                    OfferPrice = 50.0m
                },
                new Product
                {
                    Name = "Cookies",
                    Price = 95.0m,
                    Image = "cookie.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Coffee",
                    Price = 154.0m,
                    Image = "toffee.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Chocolate Bar",
                    Price = 32.0m,
                    Image = "chocolate_bar.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Cheese",
                    Price = 36.0m,
                    Image = "cheese.png",
                    HasOffer = true,
                    OfferPrice = 25.0m
                },
                new Product
                {
                    Name = "Carrot",
                    Price = 15.0m,
                    Image = "carrot.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Canned Food",
                    Price = 89.0m,
                    Image = "canned_food.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Soda",
                    Price = 45.0m,
                    Image = "can.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Candies",
                    Price = 55.0m,
                    Image = "candy.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Cake",
                    Price = 250.0m,
                    Image = "cake.png",
                    HasOffer = true,
                    OfferPrice = 200.0m
                },
                new Product
                {
                    Name = "Bread",
                    Price = 100.0m,
                    Image = "bread_1.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Bread",
                    Price = 85.0m,
                    Image = "bread.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Banana",
                    Price = 15.0m,
                    Image = "banana.png",
                    HasOffer = true,
                    OfferPrice = 10.0m
                },
                new Product
                {
                    Name = "Apple",
                    Price = 40.0m,
                    Image = "apple.png",
                    HasOffer = false
                },
                new Product
                {
                    Name = "Alcohol",
                    Price = 370.0m,
                    Image = "alcohol.png",
                    HasOffer = false
                },
            };

            var pageItems =
                items.Skip(lastIndex)
                    .Take(10);

            foreach (var item in pageItems)
            {
                Products.Add(item);
            }
        }
    }
}
