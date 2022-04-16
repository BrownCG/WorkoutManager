using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WorkoutManager.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class ExerciseDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        public string Id { get; set; }

        
    }
}
