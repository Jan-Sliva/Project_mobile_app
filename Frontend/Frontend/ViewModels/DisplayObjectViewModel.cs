﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Frontend.Views;

namespace Frontend.ViewModels
{
    public abstract class DisplayObjectViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public int Position { get; set; }

        public DisplayObjectViewModel(int position)
        {
            this.Position = position;
        }

    }
}
