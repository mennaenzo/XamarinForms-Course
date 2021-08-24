using CollectionViewDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomersView : ContentPage
    {
        public CustomersViewModel vm = new CustomersViewModel();

        public CustomersView()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            await vm.GetData();
        }

        private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            Debug.WriteLine("HorizontalDelta: " + e.HorizontalDelta);
            Debug.WriteLine("VerticalDelta: " + e.VerticalDelta);
            Debug.WriteLine("HorizontalOffset: " + e.HorizontalOffset);
            Debug.WriteLine("VerticalOffset: " + e.VerticalOffset);
            Debug.WriteLine("FirstVisibleItemIndex: " + e.FirstVisibleItemIndex);
            Debug.WriteLine("CenterItemIndex: " + e.CenterItemIndex);
            Debug.WriteLine("LastVisibleItemIndex: " + e.LastVisibleItemIndex);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //collectionView.ScrollTo(0,8); //bugeado en Android, si funciona en iOS

            var viewModel = BindingContext as CustomersViewModel;

            viewModel.Customers.Add(new Models.CustomerGroup("newGroup",
                new List<Models.Customer>
                {
                    new Models.Customer
                    {
                        Id = 100,
                        Name = "newItem",
                        Phone = "111111"
                    }
                }));

            var customer = viewModel
                .Customers
                .SelectMany(c => c)
                .FirstOrDefault(i => i.Id == 25);

            collectionView.ScrollTo(customer, animate: false, position: ScrollToPosition.Center);
        }
    }
}