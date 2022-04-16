using System;
using System.Collections.Generic;
using WorkoutManager.Models;
using System.Text;
using Xamarin.Forms;

namespace WorkoutManager.ViewModels
{
    public class NewExerciseViewModel : BaseViewModel
    {
        private string name;

        private Set[] sets;

        public NewExerciseViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        #region Commands
        private async void OnSave()
        {
            Exercise newExercise = new Exercise()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Sets = new Set[] { new Set() { Repetitions = 1, Weight = 50 } }
            };

            await DataStore.AddExerciseAsync(newExercise);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
        #endregion
    }
}
