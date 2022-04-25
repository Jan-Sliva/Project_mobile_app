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
        public InfoScreenPage(InfoScreenViewModel viewModel)
        {
            Init(viewModel);
            this.SetBinding(TitleProperty, "Title");
            Content = new CollectionView() {ItemsSource = viewModel.DisplayObjects,
                ItemTemplate = new InfoScreenDataTemplateSelector()};
            InitializeComponent();

        }
    }
                                                    
    public class InfoScreenDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate DonePasswordTemplate { get; set; }
        public DataTemplate NotDonePasswordTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is TextViewModel) return TextTemplate;
            else if (item is GamePasswordViewModel password)
            {
                if (password.IsDone) return DonePasswordTemplate;
                else return NotDonePasswordTemplate;
            }
            return null;
        }
    }
}