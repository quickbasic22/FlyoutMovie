using FlyoutMovie.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
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
            Movie movieEditable = new Movie();
            movieEditable.Id = this.Id;
            movieEditable.Title = this.title;
            movieEditable.Imdb_Id = this.Imdb_Id;
            movieEditable.Year = this.Year;
            DataStore.Update(movieEditable);
            DataStore.SaveChanges();
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

        public string  Imdb_Id
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

        public void LoadItemId(int itemId)
        {
            try
            {
                MovieEdit = DataStore.Movies.Find(itemId);
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
    }
}
