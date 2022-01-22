using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.ViewModels
{
    // not implemented
    public class PictureViewModel : DisplayObjectViewModel 
    {
        public byte[] ImageArray { get; set; }
        public PictureViewModel(InfoScreenViewModel infoScreenViewModel, Picture picture, int position) // TODO
        {
            this.Title = picture.Title;
            this.ImageArray = picture.Image;
            this.Position = position;
            this.BaseObject = picture;
            this.InfoScreenViewModel = infoScreenViewModel;
        }
    }
}
