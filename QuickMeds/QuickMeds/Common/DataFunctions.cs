using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using QuickMeds.Models;
using Action = QuickMeds.Models.Action;
using System.Linq;

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

        public Task<Medication> GetMedicationsAsync(int Medication_ID) {
            return _database.Table<Medication>()
                            .Where(i => i.Medication_ID == Medication_ID)
                            .FirstOrDefaultAsync();
        }

        public Task<List<MedicationList>> GetMedicationListByGroup(string letterGroup) {
            Task<List<MedicationList>> l;
            string query = "";
            foreach (char c in letterGroup) {
                query += "SELECT Brand_Name AS MedicationName, 'B' AS MedicationType, Generic_Name AS MedicationAKA, BT_Flag AS MedicationBTFlag " +
                    "FROM [MEDICATIONS] WHERE Brand_Name LIKE '" + c + "%' " + 
                    "UNION " +
                    "SELECT Generic_Name AS MedicationName, 'G' AS MedicationType, Brand_Name AS MedicationAKA, BT_Flag AS MedicationBTFlag " +
                    "FROM [MEDICATIONS] WHERE Generic_Name LIKE '" + c + "%' " +
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
                            .Where(i => i.Condition_ID == conditionID)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Action>> GetActionAsync() {
            return _database.Table<Action>().ToListAsync();
        }

        public Task<Action> GetActionAsync(int actionID) {
            return _database.Table<Action>()
                            .Where(i => i.Action_ID == actionID)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Control>> GetControlAsync() {
            return _database.Table<Control>().ToListAsync();
        }

        public Task<Control> GetControlAsync(int controlID) {
            return _database.Table<Control>()
                            .Where(i => i.Control_ID == controlID)
                            .FirstOrDefaultAsync();
        }
    }
}
