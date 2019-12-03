using QuickMeds.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickMeds.Common {
    public class DataFunctions {
        /// <summary>
        /// 
        /// </summary>
        readonly SQLiteAsyncConnection _database;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbPath"></param>
        public DataFunctions(string dbPath) {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Medication>().Wait();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Medication>> GetMedicationsAsync() {
            Task<List<Medication>> m;
            m = _database.Table<Medication>().ToListAsync();
            return m;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicationID"></param>
        /// <returns></returns>
        public Task<Medication> GetMedicationsAsync(int medicationID) {
            return _database.Table<Medication>()
                            .Where(i => i.MedicationID == medicationID)
                            .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="letterGroup"></param>
        /// <returns></returns>
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
            // Console.WriteLine(query);
            l = _database.QueryAsync<MedicationList>(query);
            Console.WriteLine(l);
            return l;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<Condition>> GetConditionsAsync() {
            return _database.Table<Condition>().ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditionID"></param>
        /// <returns></returns>
        public Task<Condition> GetConditionAsync(int conditionID) {
            return _database.Table<Condition>()
                            .Where(i => i.ConditionID == conditionID)
                            .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<ActionClass>> GetActionAsync() {
            return _database.Table<ActionClass>().ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionClassID"></param>
        /// <returns></returns>
        public Task<ActionClass> GetActionAsync(int actionClassID) {
            return _database.Table<ActionClass>()
                            .Where(i => i.ActionClassID == actionClassID)
                            .FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<ControlClass>> GetControlAsync() {
            return _database.Table<ControlClass>().ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlClassID"></param>
        /// <returns></returns>
        public Task<ControlClass> GetControlAsync(int controlClassID) {
            return _database.Table<ControlClass>()
                            .Where(i => i.ControlClassID == controlClassID)
                            .FirstOrDefaultAsync();
        }
    }
}
