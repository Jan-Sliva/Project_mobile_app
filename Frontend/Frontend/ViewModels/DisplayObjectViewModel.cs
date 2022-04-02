using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Frontend.ViewModels
{
    public abstract class DisplayObjectViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public int Position { get; set; }

        protected InfoScreenViewModel InfoScreenViewModel { get; set; }

    }
}
