using FlyoutMovie.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
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
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                MovieTitle = item.Title;
                Released = item.Released;
                MediaFormat = item.MediaFormat;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
