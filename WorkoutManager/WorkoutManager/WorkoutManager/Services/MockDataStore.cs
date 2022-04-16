using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutManager.Models;

namespace WorkoutManager.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        private List<Workout> workouts { get; set; }

        private List<Exercise> exercises { get; set; }


        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            exercises = GetExercises();

            workouts = GetWorkouts();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(exercises);
        }

        #region ExampleExercises
        private List<Exercise> GetExercises()
        {
            var fiftyLbCurls = new Exercise
            {
                Id = Guid.NewGuid().ToString(),
                Completed = false,
                Duration = TimeSpan.Zero,
                Name = "50lb curl",
                Sets = new Set[] {
                    new Set { Id = Guid.NewGuid().ToString(), Repetitions = 8, Weight = 50},
                    new Set { Id = Guid.NewGuid().ToString(), Repetitions = 8, Weight = 50 },
                    new Set { Id = Guid.NewGuid().ToString(), Repetitions = 6, Weight = 50 },
                }
            };

            var seventyLbCurls = new Exercise
            {
                Id = Guid.NewGuid().ToString(),
                Completed = false,
                Duration = TimeSpan.Zero,
                Name = "70lb curl",
                Sets = new Set[] {
                    new Set { Id = Guid.NewGuid().ToString(), Repetitions = 6, Weight = 70},
                    new Set { Id = Guid.NewGuid().ToString(), Repetitions = 6, Weight = 70 },
                    new Set { Id = Guid.NewGuid().ToString(), Repetitions = 4, Weight = 70 },
                }
            };

            var sitUps = new Exercise
            {
                Id = Guid.NewGuid().ToString(),
                Completed = false,
                Duration = TimeSpan.Zero,
                Name = "SitUps",
                Sets = new Set[] {
                    new Set { Id = Guid.NewGuid().ToString(), Repetitions = 20, Weight = -1},
                    new Set { Id = Guid.NewGuid().ToString(), Repetitions = 20, Weight = -1 },
                    new Set { Id = Guid.NewGuid().ToString(), Repetitions = 20, Weight = -1 },
                }
            };

            var exampleExercises = new List<Exercise>
            {
                fiftyLbCurls,
                seventyLbCurls,
                sitUps
            };

            return exampleExercises;
        }
        #endregion

        #region ExampleWorkouts
        private List<Workout> GetWorkouts()
        {
            var workouts = new List<Workout>();
            var armWorkout = new Workout { 
                Description = "Bicep Blaster", 
                Id = Guid.NewGuid().ToString(), 
                Exercises = new Exercise[] { exercises[0], exercises[1] }, Name = "Arms"
            };
            var totalWorkout = new Workout
            {
                Description = "All Your Exercises",
                Id = Guid.NewGuid().ToString(),
                Exercises = exercises.ToArray(),
                Name = "Everything"
            };
            workouts.Add(armWorkout);
            workouts.Add(totalWorkout);

            return workouts;
        }
        #endregion
    }
}