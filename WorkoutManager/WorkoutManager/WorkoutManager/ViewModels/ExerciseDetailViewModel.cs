using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using WorkoutManager.Models;
using WorkoutManager.Services;

namespace WorkoutManager.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class ExerciseDetailViewModel : BaseViewModel
    {
        private string id;
        private string name;
        private Set[] sets;
        private bool completed;
        private TimeSpan duration;
        
        public string Id { 
            get => id; 
            set{
                id = value;
                LoadExerciseId(value);
            } 
        }
        public string Name {
            get => name;
            set => SetProperty(ref name, value);
        }
        public Set[] Sets {
            get => sets;
            set => SetProperty(ref sets, value);
        }
        public bool Completed {
            get => completed;
            set => SetProperty(ref completed, value);
        }
        public TimeSpan Duration {
            get => duration;
            set => SetProperty(ref duration, value);
        }

        public async void LoadExerciseId(string Id){
            try{
                var exercise = await DataStore.GetExerciseAsync(Id);
                Id = exercise.Id;
                Name = exercise.Name;
                Sets = exercise.Sets;
                Completed = exercise.Completed;
                Duration = exercise.Duration;
            }
            catch (Exception){
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
