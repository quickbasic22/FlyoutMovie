using FlyoutMovie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlyoutMovie.Services
{
    public class MockDataStore : IDataStore<Movie>
    {
        readonly SQLite.SQLiteAsyncConnection database;
        
        public MockDataStore(string dbPath)
        {
            database = new SQLite.SQLiteAsyncConnection(dbPath);
            try
            {
                database.CreateTableAsync<Movie>().Wait();
                database.CreateTableAsync<MoviesDetails>().Wait();
                database.CreateTableAsync<Actors>().Wait();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        public async Task<int> InsertItemAsync(Movie movie)
        {
            return await database.InsertAsync(movie);
        }
               
        public async Task<int> UpdateItemAsync(Movie movie)
        {
            return await database.UpdateAsync(movie);
        }

        public async Task<int> DeleteItemAsync(Movie movie)
        {
            return await database.DeleteAsync(movie);
        }

        public async Task<Movie> GetItemAsync(int id)
        {
            return await database.Table<Movie>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Movie>> GetItemsAsync(bool forceRefresh = false)
        {

            return await database.Table<Movie>().ToListAsync();
        }
    }
}