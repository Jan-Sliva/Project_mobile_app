using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Frontend.Views;

namespace Frontend.ViewModels
{
    public abstract class DisplayObjectViewModel<T> : BaseViewModel where T : BasePage
    {
        public string Title { get; set; }

        public int Position { get; set; }

        protected InfoScreenViewModel<T> InfoScreenViewModel { get; set; }

    }
}
