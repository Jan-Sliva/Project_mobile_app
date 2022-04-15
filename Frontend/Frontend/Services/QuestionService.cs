using System;
using System.Collections.Generic;
using System.Text;
using Frontend.Models;
using Frontend.ViewModels;
using Frontend.Services;

namespace Frontend.Services
{
    public abstract class QuestionService
    {
        public abstract void Ask();

        public abstract void Hide();
    }
}
