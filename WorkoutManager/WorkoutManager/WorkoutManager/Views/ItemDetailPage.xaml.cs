using System.ComponentModel;
using WorkoutManager.ViewModels;
using Xamarin.Forms;

namespace WorkoutManager.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}