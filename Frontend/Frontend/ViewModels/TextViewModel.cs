using Frontend.Models;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.ViewModels
{
    public class TextViewModel : DisplayObjectViewModel
    {

        public string Text { get; set; }

        public TextViewModel(Text text, int position) : base(position)
        {
            this.Title = text.Title;
            this.Text = text.OwnText;
        } 
    }
}