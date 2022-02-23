using FlyoutMovie.Models;
using FlyoutMovie.ViewModels;
using System;
using Xamarin.Forms;

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
            _viewModel.DataStore.Remove(item);
            await _viewModel.DataStore.SaveChangesAsync();
            _viewModel.Items.Remove(item);
            _viewModel.ExecuteLoadItemsCommand();
            await Shell.Current.GoToAsync("..");

        }
    }
}