using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.ViewModels
{
    public class ConfirmedTextEventArgs : EventArgs
    {
        private readonly string text;

        public ConfirmedTextEventArgs(string text)
        {
            this.text = text;
        }

        public string Text { get { return text; } }
    }
}
