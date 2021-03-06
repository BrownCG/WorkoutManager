using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutManager.Models;

namespace WorkoutManager.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

        Task<IEnumerable<Workout>> GetWorkoutsAsync(bool forceRefresh = false);
        Task<Exercise> GetExerciseAsync(string id);
        Task<bool> AddExerciseAsync(Exercise exercise);
        Task<IEnumerable<Exercise>> GetExercisesAsync(bool forceRefresh = false);
    }
}
