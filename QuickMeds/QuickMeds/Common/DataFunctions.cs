using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using QuickMeds.Models;
using Action = QuickMeds.Models.Action;

namespace QuickMeds.Data {
    public class DataFunctions {
        readonly SQLiteAsyncConnection _database;

        public DataFunctions(string dbPath) {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MEDICATIONS>().Wait();
        }

        public Task<List<MEDICATIONS>> GetMedicationsAsync() {
            return _database.Table<MEDICATIONS>().ToListAsync();
        }

        public Task<MEDICATIONS> GetMedicationsAsync(int MEDID) {
            return _database.Table<MEDICATIONS>()
                            .Where(i => i.MEDID == MEDID)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Condition>> GetConditionsAsync() {
            return _database.Table<Condition>().ToListAsync();
        }

        public Task<Condition> GetConditionAsync(int conditionID) {
            return _database.Table<Condition>()
                            .Where(i => i.ConditionID == conditionID)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Action>> GetActionAsync() {
            return _database.Table<Action>().ToListAsync();
        }

        public Task<Action> GetActionAsync(int actionID) {
            return _database.Table<Action>()
                            .Where(i => i.ActionID == actionID)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Control>> GetControlAsync() {
            return _database.Table<Control>().ToListAsync();
        }

        public Task<Control> GetControlAsync(int controlID) {
            return _database.Table<Control>()
                            .Where(i => i.ControlID == controlID)
                            .FirstOrDefaultAsync();
        }
    }
}
