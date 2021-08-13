using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyDemoPage : ContentPage
    {
        public EmptyDemoPage()
        {
            InitializeComponent();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var isToggled = e.Value;
            collectionView.EmptyView = isToggled ? Resources["NoResultsView"] : Resources["ConnectivityIssue"];
        }
    }
}