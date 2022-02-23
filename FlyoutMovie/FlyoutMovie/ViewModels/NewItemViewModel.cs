using FlyoutMovie.Models;
using System;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using System.Collections;

namespace FlyoutMovie.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string title;
        private string imdb_id;
        private int year;

        public NewItemViewModel()
        {
            MovieTitle = title;
            Imdb_Id = imdb_id;
            Year = year;
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

        private async void OnSave()
        {
            var list = DataStore.Movies.ToList().Last();
            var lastId = list.Id++;
            lastId = lastId++;
            Movie newItem = new Movie()
            {
                Id = lastId,
                Title = title,
                Imdb_Id = imdb_id,
                Year = year
            };

            try
            {
                await DataStore.Movies.AddAsync(newItem);
                await DataStore.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Debug.WriteLine(ex.InnerException.ToString());
                foreach (IDictionary dictionary in ex.Data)
                {
                    Debug.WriteLine(dictionary.Keys);
                    Debug.WriteLine(dictionary.Values);
                }
            }
            

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
