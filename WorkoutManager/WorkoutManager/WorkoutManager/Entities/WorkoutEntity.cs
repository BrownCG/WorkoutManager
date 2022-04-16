using System;
using System.Collections.Generic;
using WorkoutManager.Models;
using System.Text;

namespace WorkoutManager.Entities
{
    public class WorkoutEntity
    {
        public Workout WorkoutRecord { get; set; }

        public Guid Id { get; set; }

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

        public double PercentCompleted { get; set; }

        public DateTime ScheduledDate { get; set; }
    }
}
