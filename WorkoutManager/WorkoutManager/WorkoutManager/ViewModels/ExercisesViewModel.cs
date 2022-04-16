using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WorkoutManager.Models;
using WorkoutManager.Views;
using Xamarin.Forms;

namespace WorkoutManager.ViewModels
{
    public class ExercisesViewModel : BaseViewModel
    {
        private Exercise _selectedExercise;

        public ObservableCollection<Exercise> Exercises { get; }
        public Command LoadExercisesCommand { get; }
        public Command AddExerciseCommand { get; }
        public Command<Exercise> ExerciseTapped { get; }

        public ExercisesViewModel()
        {
            Title = "Exercises";
            Exercises = new ObservableCollection<Exercise>();
            LoadExercisesCommand = new Command(async () => await ExecuteLoadExercisesCommand());

            ExerciseTapped = new Command<Exercise>(OnExerciseSelected);

            //AddExerciseCommand = new Command(OnAddExercise);
        }

        async Task ExecuteLoadExercisesCommand()
        {
            IsBusy = true;

            try
            {
                Exercises.Clear();
                var exrcs = await DataStore.GetExercisesAsync(true);
                foreach (var ex in exrcs)
                {
                    Exercises.Add(ex);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedExercise = null;
        }

        public Exercise SelectedExercise
        {
            get => _selectedExercise;
            set
            {
                SetProperty(ref _selectedExercise, value);
                OnExerciseSelected(value);
            }
        }

        //private async void OnAddExercise(object obj)
        //{
        //    await Shell.Current.GoToAsync(nameof(NewExercisePage));
        //}

        async void OnExerciseSelected(Exercise ex)
        {
            if (ex == null)
                return;

            // This will push the ExerciseDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailPage)}?{nameof(ExerciseDetailViewModel.Id)}={ex.Id}");
        }
    }
}