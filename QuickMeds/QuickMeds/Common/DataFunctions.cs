using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using QuickMeds.Models;

namespace QuickMeds.Data {
    public class DataFunctions {
        readonly SQLiteAsyncConnection _database;

        public DataFunctions(string dbPath) {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Medication>().Wait();
        }

        public Task<List<Medication>> GetMedicationsAsync() {
            return _database.Table<Medication>().ToListAsync();
        }
    }
}
