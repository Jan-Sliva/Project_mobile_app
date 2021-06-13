using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopPage : ContentPage
    {
        public StopPage(StopViewModel stopViewModel)
        {
            BindingContext = stopViewModel;
            InitializeComponent();
        }
    }

    public class StopDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate DonePasswordTemplate { get; set; }
        public DataTemplate NotDonePasswordTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item.GetType().Equals(typeof(TextViewModel))) return TextTemplate;
            else if (item.GetType().Equals(typeof(GamePasswordViewModel)))
            {
                if ((item as GamePasswordViewModel).IsDone) return DonePasswordTemplate;
                else return NotDonePasswordTemplate;
            }
            return null;
        }
    }
}