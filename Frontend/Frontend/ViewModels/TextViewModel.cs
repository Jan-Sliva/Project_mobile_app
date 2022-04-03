using Frontend.Models;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.ViewModels
{
    public class TextViewModel<T> : DisplayObjectViewModel<T> where T : BasePage
    {

        public string Text { get; set; }

        public TextViewModel(InfoScreenViewModel<T> infoScreenViewModel, Text text, int position)
        {
            this.Title = text.Title;
            this.Text = text.OwnText;
            this.Position = position;
            this.InfoScreenViewModel = infoScreenViewModel;
        } 
    }
}
