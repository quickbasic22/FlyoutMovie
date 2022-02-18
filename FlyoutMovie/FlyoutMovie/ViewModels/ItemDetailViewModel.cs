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
        private DateTime released;
        private string mediaformat;
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
            movieEditable.Released = this.released;
            movieEditable.MediaFormat = this.mediaformat;
            await DataStore.UpdateItemAsync(movieEditable);
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

        public DateTime Released
        {
            get => released;
            set => SetProperty(ref released, value);
        }

        public string MediaFormat
        {
            get => mediaformat;
            set => SetProperty(ref mediaformat, value);
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
                MovieEdit = await DataStore.GetItemAsync(ItemId);
                Id = MovieEdit.Id;
                MovieTitle = MovieEdit.Title;
                Released = MovieEdit.Released;
                MediaFormat = MovieEdit.MediaFormat;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Movie");
            }
        }
    }
}
