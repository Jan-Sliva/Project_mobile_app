using Frontend.Models;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.ViewModels
{
    // not implemented
    public class PictureViewModel : DisplayObjectViewModel
    {
        public byte[] ImageArray { get; set; }
        public PictureViewModel(Picture picture, int position) : base(position) // TODO
        {
            this.Title = picture.Title;
            this.ImageArray = picture.Image;
        }
    }
}