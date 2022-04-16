using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutManager.Models
{
    public class Workout
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Exercise[] Exercises { get; set; }

        public string Id { get; set; }
    }
}
