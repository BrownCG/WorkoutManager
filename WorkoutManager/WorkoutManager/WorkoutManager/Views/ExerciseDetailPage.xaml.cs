using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDetailPage : ContentPage
    {
        public ExerciseDetailPage()
        {
            InitializeComponent();
            BindingContext = new ExerciseDetailViewModel();
        }
    }
}