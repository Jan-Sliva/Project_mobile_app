using Frontend.Models;
using Frontend.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.ViewModels
{
    // not implemented
    public class PictureViewModel<T> : DisplayObjectViewModel<T> where T : BasePage
    {
        public byte[] ImageArray { get; set; }
        public PictureViewModel(InfoScreenViewModel<T> infoScreenViewModel, Picture picture, int position) // TODO
        {
            this.Title = picture.Title;
            this.ImageArray = picture.Image;
            this.Position = position;
            this.InfoScreenViewModel = infoScreenViewModel;
        }
    }
}
