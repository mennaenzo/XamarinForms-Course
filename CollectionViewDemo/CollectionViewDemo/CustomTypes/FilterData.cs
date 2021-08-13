using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollectionViewDemo.CustomTypes
{
    public class FilterData : BindableObject
    {
        public static readonly BindableProperty FilterProperty = BindableProperty.Create(nameof(Filter), typeof(String), typeof(FilterData), null);
        private string filter;

        public String Filter
        {
            get { return (String) GetValue(FilterProperty); }
            set
            {
                SetValue(FilterProperty, value);
            }
        }
    }
}
