using System;
using System.Collections.Generic;
using WorkoutManager.Models;
using System.Text;

namespace WorkoutManager.Entities
{
    public class WorkoutEntity
    {
        #region Properties
        public Workout WorkoutRecord { get; set; }

        public Guid Id { get; set; }

        public DateTime ScheduledDate { get; set; }
        #endregion

        public TimeSpan WorkoutDuration { 
            get { 
                TimeSpan totalTimespan = TimeSpan.Zero;
                for (int i = 0; i< WorkoutRecord.Exercises.Length; i++)
                {
                    totalTimespan += WorkoutRecord.Exercises[i].Duration;
                }
                return totalTimespan;
            } 
        }

        public double PercentCompleted { 
            get {
                int totalComplete = 0;
                for (int i = 0; i < WorkoutRecord.Exercises.Length; i++)
                {
                    if (WorkoutRecord.Exercises[i] != null && WorkoutRecord.Exercises[i].Completed)
                    {
                        totalComplete++;
                    }
                }
                return (double)totalComplete/(WorkoutRecord.Exercises.Length);
            }
        }

    }
}
