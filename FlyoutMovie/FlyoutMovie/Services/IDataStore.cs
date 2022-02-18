using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlyoutMovie.Services
{
    public interface IDataStore<T>
    {
        Task<int> InsertItemAsync(T item);
        Task<int> UpdateItemAsync(T item);
        Task<int> DeleteItemAsync(T id);
        Task<T> GetItemAsync(int id);
        Task<List<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
