using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutManager.Models
{
    public class Set
    {
        public int Weight { get; set; }

        public int Repetitions { get; set; }

        public TimeSpan Duration { get; set; }

        public bool Completed { get; set; }

        public string Id { get; set; }
    }
}
