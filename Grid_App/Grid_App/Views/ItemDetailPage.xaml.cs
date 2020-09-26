using System.ComponentModel;
using Xamarin.Forms;
using Grid_App.ViewModels;

namespace Grid_App.Views
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