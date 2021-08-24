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
        public CustomersView()
        {
            InitializeComponent();
            BindingContext = new CustomersViewModel();
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

            var customer = viewModel
                .Customers
                .SelectMany(c => c)
                .FirstOrDefault(i => i.Id == 25);

            collectionView.ScrollTo(customer, animate: false);
        }
    }
}