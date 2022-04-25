using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Frontend.ViewModels;
using Frontend.Models;
using Xamarin.Forms.Maps;
using Frontend.Services;
using System.Threading;
using Frontend.Resources;
using Frontend.Smart;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : BasePage
    {
        public MapPage(MapViewModel viewModel)
        {
            InitializeComponent();

            Init(viewModel);
            this.SetBinding(TitleProperty, "Title");

            MapSpan mapSpan = new MapSpan(new Position(), MapResources.InitialFocusLatitude, MapResources.InitialFocusLongitude);

            var map = new SmartMap(mapSpan)
            {
                MapType = MapResources.TypoOfMap,
                IsShowingUser = MapResources.IsShowingUser
            };

            map.SetBinding(SmartMap.SmartPinsProperty, "PinViewModels");

            Content = map;

        }
    }
}
