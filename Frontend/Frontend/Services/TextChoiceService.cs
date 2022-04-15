using Frontend.Models;
using Frontend.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Services
{
    public class TextChoiceService : ChoiceService
    {
        public ChoiceForTextQuestion Model;

        public TextChoiceService(ChoiceForTextQuestion model)
        {
            Model = model;
        }
    }
}
