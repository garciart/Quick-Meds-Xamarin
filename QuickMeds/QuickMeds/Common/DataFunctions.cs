using QuickMeds.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<Medication> GetMedicationsAsync(int medicationID) {
            return _database.Table<Medication>()
                            .Where(i => i.MedicationID == medicationID)
                            .FirstOrDefaultAsync();
        }

        public Task<List<MedicationList>> GetMedicationListByGroup(string letterGroup) {
            Task<List<MedicationList>> l;
            string query = "";
            foreach (char c in letterGroup) {
                query += "SELECT BrandName AS MedicationName, 'B' AS MedicationType, GenericName AS MedicationAKA, BTFlag AS MedicationBTFlag " +
                    "FROM [Medication] WHERE BrandName LIKE '" + c + "%' " + 
                    "UNION " +
                    "SELECT GenericName AS MedicationName, 'G' AS MedicationType, BrandName AS MedicationAKA, BTFlag AS MedicationBTFlag " +
                    "FROM [Medication] WHERE GenericName LIKE '" + c + "%' " +
                    "UNION ";
            }
            query = query.Substring(0, query.LastIndexOf("UNION "));
            query += "ORDER BY MedicationName ASC;";
            l = _database.QueryAsync<MedicationList>(query);
            return l;
        }

        public Task<List<Condition>> GetConditionsAsync() {
            return _database.Table<Condition>().ToListAsync();
        }

        public Task<Condition> GetConditionAsync(int conditionID) {
            return _database.Table<Condition>()
                            .Where(i => i.ConditionID == conditionID)
                            .FirstOrDefaultAsync();
        }

        public Task<List<ActionClass>> GetActionAsync() {
            return _database.Table<ActionClass>().ToListAsync();
        }

        public Task<ActionClass> GetActionAsync(int actionClassID) {
            return _database.Table<ActionClass>()
                            .Where(i => i.ActionClassID == actionClassID)
                            .FirstOrDefaultAsync();
        }

        public Task<List<ControlClass>> GetControlAsync() {
            return _database.Table<ControlClass>().ToListAsync();
        }

        public Task<ControlClass> GetControlAsync(int controlClassID) {
            return _database.Table<ControlClass>()
                            .Where(i => i.ControlClassID == controlClassID)
                            .FirstOrDefaultAsync();
        }
    }
}
