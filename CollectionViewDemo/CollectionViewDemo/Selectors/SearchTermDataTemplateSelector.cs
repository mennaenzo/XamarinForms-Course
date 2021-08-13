using CollectionViewDemo.CustomTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollectionViewDemo.Selectors
{
    public class SearchTermDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate SecondaryTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            string query = ((FilterData)item).Filter;

            if(query.ToLower().Equals("xamarin"))
            {
                return DefaultTemplate;
            }
            else
            {
                return SecondaryTemplate;
            }
        }
    }
}
