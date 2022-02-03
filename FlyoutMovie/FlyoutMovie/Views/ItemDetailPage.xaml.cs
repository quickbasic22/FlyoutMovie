using FlyoutMovie.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FlyoutMovie.Views
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