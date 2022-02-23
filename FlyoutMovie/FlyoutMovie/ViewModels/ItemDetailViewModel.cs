using FlyoutMovie.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace FlyoutMovie.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private int id;
        private string title;
        private string imdb_id;
        private int year;
        private Movie movie;

        public Command SaveCommand { get; set; }
        

        public ItemDetailViewModel()
        {
            SaveCommand = new Command(OnSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void OnSave()
        {
            MovieEdit.Id = Id;
            MovieEdit.Title = Title;
            MovieEdit.Imdb_Id = Imdb_Id;
            MovieEdit.Year = Year;
            DataStore.Update<Movie>(MovieEdit);
            await DataStore.SaveChangesAsync();
            Items.Remove(MovieEdit);
            ExecuteLoadItemsCommand();
            await Shell.Current.GoToAsync("..");
        }

        public Movie MovieEdit
        {
            get => movie;
            set => SetProperty(ref movie, value);
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

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                MovieEdit = await DataStore.Movies.FindAsync(itemId);
                Id = MovieEdit.Id;
                MovieTitle = MovieEdit.Title;
                Imdb_Id = MovieEdit.Imdb_Id;
                Year = MovieEdit.Year;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Movie");
            }
        }

        public void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = DataStore.Movies
                foreach (var movie in items)
                {
                    Items.Add(movie);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
