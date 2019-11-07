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

        public Task<List<MedicationList>> GetMedicationListByGroup(string letterGroup) {
            Task<List<MedicationList>> l;
            string query = "";
            foreach (char c in letterGroup) {
                query += "SELECT BNAME AS MedicationName, 'B' AS MedicationType, GNAME AS MedicationAKA, BTFLAG AS MedicationBTFlag " +
                    "FROM [MEDICATIONS] WHERE BNAME LIKE '" + c + "%' " + 
                    "UNION " +
                    "SELECT GNAME AS MedicationName, 'G' AS MedicationType, BNAME AS MedicationAKA, BTFLAG AS MedicationBTFlag " +
                    "FROM [MEDICATIONS] WHERE GNAME LIKE '" + c + "%' " +
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
