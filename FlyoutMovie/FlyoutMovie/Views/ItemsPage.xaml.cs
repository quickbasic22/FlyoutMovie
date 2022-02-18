using FlyoutMovie.Models;
using FlyoutMovie.ViewModels;
using FlyoutMovie.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlyoutMovie.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        protected async void SwipeDelete_Invoked(object sender, EventArgs e)
        {
            var swipe = sender as SwipeItem;
            var item = swipe.BindingContext as Movie;
            await _viewModel.DataStore.DeleteItemAsync(item);
            _viewModel.Items.Remove(item);
            await _viewModel.ExecuteLoadItemsCommand();
            await Shell.Current.GoToAsync("..");

        }
    }
}