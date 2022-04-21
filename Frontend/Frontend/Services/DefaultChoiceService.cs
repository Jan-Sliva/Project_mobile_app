using Frontend.Models;
using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Services
{
    public class DefaultChoiceService : ChoiceService
    {

        public DefaultChoice Model;

        public DefaultChoiceService(DefaultChoice model, MapViewModel map) 
            :base(model, map)
        {
            Model = model;
        }
    }
}
