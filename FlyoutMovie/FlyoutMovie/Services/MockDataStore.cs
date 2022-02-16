using FlyoutMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyoutMovie.Services
{
    public class MockDataStore : IDataStore<Movie>
    {
        readonly List<Movie> items;

        public MockDataStore()
        {
            items = new List<Movie>()
            {
                new Movie { Id = 1, Title = "Pain and Gain", Released=DateTime.Now.AddYears(-3).AddMonths(-9), MediaFormat = "DVD" },
                new Movie { Id = 2, Title = "Jaws", Released=DateTime.Now.AddYears(-10).AddMonths(-2), MediaFormat = "Blueray" },
                new Movie { Id = 3, Title = "Friday The 13th", Released=DateTime.Now.AddYears(-8).AddMonths(-1), MediaFormat = "HD" },
                new Movie { Id = 4, Title = "Mexico", Released=DateTime.Now.AddYears(-9).AddMonths(-9), MediaFormat = "UHD" },
                new Movie { Id = 5, Title = "Go Day", Released=DateTime.Now.AddYears(-11).AddMonths(-9), MediaFormat = "IMAX" },
                new Movie { Id = 6, Title = "The Sixth Sense", Released=DateTime.Now.AddYears(-4).AddMonths(-3), MediaFormat = "DVD" }
            };
        }

        public async Task<bool> AddItemAsync(Movie item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Movie item)
        {
            var oldItem = items.Where((Movie arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Movie arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Movie> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Movie>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}