using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutManager.Models
{
    public class Exercise
    {
        public string Name { get; set; }

        public Set[] Sets { get; set; }

        public bool Completed { get; set; }

        public TimeSpan Duration { get; set; }

        public string Id { get; set; }
    }
}
