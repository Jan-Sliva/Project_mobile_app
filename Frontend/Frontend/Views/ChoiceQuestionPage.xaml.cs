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
    public partial class ChoiceQuestionPage : ContentPage
    {
        public ChoiceQuestionPage(ChoiceQuestionViewModel choiceQuestion)
        {
            InitializeComponent();
            BindingContext = choiceQuestion;
        }
    }
}