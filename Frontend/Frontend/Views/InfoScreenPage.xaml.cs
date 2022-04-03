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
    public partial class InfoScreenPage : BasePage
    {
        public static InfoScreenPage Constructor<T>(PageViewModel<T> viewModel) where T : BasePage
        {
            InfoScreenPage page = new InfoScreenPage();

            page.Init(viewModel);
            page.InitializeComponent();

            return page;
        }
    }

    public class InfoScreenDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate DonePasswordTemplate { get; set; }
        public DataTemplate NotDonePasswordTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is TextViewModel<InfoScreenPage>) return TextTemplate;
            else if (item is GamePasswordViewModel<InfoScreenPage> password)
            {
                if (password.IsDone) return DonePasswordTemplate;
                else return NotDonePasswordTemplate;
            }
            return null;
        }
    }
}