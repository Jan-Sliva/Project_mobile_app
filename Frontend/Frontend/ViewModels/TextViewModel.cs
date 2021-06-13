using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.ViewModels
{
    public class TextViewModel : DisplayObjectViewModel
    {

        public string Text { get; set; }

        public TextViewModel(InfoScreenViewModel infoScreenViewModel, Text text, int position)
        {
            this.Title = text.Title;
            this.Text = text.OwnText;
            this.Position = position;
            this.BaseObject = text;
            this.InfoScreenViewModel = infoScreenViewModel;
        } 
    }
}
