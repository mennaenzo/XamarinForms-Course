using CollectionViewDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollectionViewDemo.Selectors
{
    public class ProductDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var collection = container as CollectionView;
            
            if (container != null)
            {
                var product = item as Product;

                if (product.HasOffer)
                {
                    return (DataTemplate) collection.Resources["productWithOffer"];
                }
                else
                {
                    return (DataTemplate)collection.Resources["product"];
                }
            }
            return null;
        }
    }
}
