using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Services
{
    public class DefaultChoiceService : ChoiceService
    {

        public DefaultChoice Model;

        public DefaultChoiceService(DefaultChoice model)
        {
            Model = model;
        }
    }
}
