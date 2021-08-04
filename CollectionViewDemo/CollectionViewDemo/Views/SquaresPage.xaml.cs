using CollectionViewDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SquaresPage : ContentPage
    {
        public SquaresPage()
        {
            InitializeComponent();

            var colors =
                ColorsService.GetColors(25);

            BindingContext = new ObservableCollection<SquareColor>(colors);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            BoxView box = sender as BoxView;

            box.HeightRequest = box.WidthRequest = 300;
        }
    }
}