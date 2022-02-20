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
            TitleOfMovie.TextChanged += TitleOfMovie_TextChanged;
        }

        private void TitleOfMovie_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = sender as Entry;
            entry.Keyboard = Keyboard.Text;
            
        }
    }
}