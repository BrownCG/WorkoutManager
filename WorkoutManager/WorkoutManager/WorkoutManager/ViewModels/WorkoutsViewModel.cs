using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WorkoutManager.Models;
using WorkoutManager.Views;
using Xamarin.Forms;


namespace WorkoutManager.ViewModels
{
    public class WorkoutsViewModel : BaseViewModel
    {
        private Workout _selectedWorkout;

        public ObservableCollection<Workout> Workouts { get; }
        public Command LoadWorkoutsCommand { get; }
        public Command AddWorkoutCommand { get; }
        public Command<Workout> WorkoutTapped { get; }

        public WorkoutsViewModel()
        {
            Title = "Workouts";
            Workouts = new ObservableCollection<Workout>();
            LoadWorkoutsCommand = new Command(async () => await ExecuteLoadWorkoutsCommand());

            WorkoutTapped = new Command<Workout>(OnWorkoutSelected);

            //AddExerciseCommand = new Command(OnAddExercise);
        }

        async Task ExecuteLoadWorkoutsCommand()
        {
            IsBusy = true;

            try
            {
                Workouts.Clear();
                var wrkts = await DataStore.GetWorkoutsAsync(true);
                foreach (var wrk in wrkts)
                {
                    Workouts.Add(wrk);
                }
            }
            catch (Exception wrk)
            {
                Debug.WriteLine(wrk);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedWorkout = null;
        }

        public Workout SelectedWorkout
        { 
            get => _selectedWorkout;
            set
            {
                SetProperty(ref _selectedWorkout, value);
                OnWorkoutSelected(value);
            }
        }

        //private async void OnAddExercise(object obj)
        //{
        //    await Shell.Current.GoToAsync(nameof(NewExercisePage));
        //}

        async void OnWorkoutSelected(Workout wrk)
        {
            if ( wrk == null)
                return;

            // This will push the ExerciseDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(WorkoutDetailPage)}?{nameof(WorkoutDetailViewModel.Id)}={wrk.Id}");
        }
    }
}