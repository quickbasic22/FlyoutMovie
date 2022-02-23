using FlyoutMovie.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FlyoutMovie.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private int id = 1;
        private string title = "Movie";
        private string imdb_id = "ds32dw32";
        private int year = 2022;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(imdb_id);
        }

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string MovieTitle
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Imdb_Id
        {
            get => imdb_id;
            set => SetProperty(ref imdb_id, value);
        }

        public int Year
        {
            get => year;
            set => SetProperty(ref year, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private void OnSave()
        {
            Movie newItem = new Movie()
            {
                Title = title,
                Imdb_Id = imdb_id,
                Year = year
            };

            DataStore.Add(newItem);
            DataStore.SaveChanges();

            // This will pop the current page off the navigation stack
            Shell.Current.GoToAsync("..");
        }
    }
}
