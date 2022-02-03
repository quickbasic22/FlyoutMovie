﻿using FlyoutMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyoutMovie.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = 1, Title = "Pain and Gain", Released=DateTime.Now.AddYears(-3).AddMonths(-9), MediaFormat = "DVD" },
                new Item { Id = 2, Title = "Jaws", Released=DateTime.Now.AddYears(-10).AddMonths(-2), MediaFormat = "Blueray" },
                new Item { Id = 3, Title = "Friday The 13th", Released=DateTime.Now.AddYears(-8).AddMonths(-1), MediaFormat = "HD" },
                new Item { Id = 4, Title = "Mexico", Released=DateTime.Now.AddYears(-9).AddMonths(-9), MediaFormat = "UHD" },
                new Item { Id = 5, Title = "Go Day", Released=DateTime.Now.AddYears(-11).AddMonths(-9), MediaFormat = "IMAX" },
                new Item { Id = 6, Title = "The Sixth Sense", Released=DateTime.Now.AddYears(-4).AddMonths(-3), MediaFormat = "DVD" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}