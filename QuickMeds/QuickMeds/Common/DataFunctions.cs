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

        public Task<List<MEDICATIONS>> GetMedicationsByInitialAsync(string letterGroup) {
            string[] stringArray = letterGroup.Split();
            return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE BNAME LIKE 'A%' OR GNAME LIKE 'A%';");
        }

        public Task<List<MEDICATIONS>> GetMedicationsInGroup(object group) {
            switch (group) {
                case "1": {
                        return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE" +
                            "BNAME LIKE 'A%' OR GNAME LIKE 'A%' OR " +
                            "BNAME LIKE 'B%' OR GNAME LIKE 'B%' OR " +
                            "BNAME LIKE 'C%' OR GNAME LIKE 'C%' " +
                            "ORDER BY BNAME, GNAME ASC;");
                    }
                case "2": {
                        return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE BNAME LIKE 'D%' OR GNAME LIKE 'D%' OR BNAME LIKE 'E%' OR GNAME LIKE 'E%' OR BNAME LIKE 'F%' OR GNAME LIKE 'F%' ORDER BY BNAME, GNAME ASC;");
                    }
                case "3": {
                        return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE" +
                            "BNAME LIKE 'G%' OR GNAME LIKE 'G%' OR " +
                            "BNAME LIKE 'H%' OR GNAME LIKE 'H%' OR " +
                            "BNAME LIKE 'I%' OR GNAME LIKE 'I%' " +
                            "ORDER BY BNAME, GNAME ASC;");
                    }
                case "4": {
                        return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE" +
                            "BNAME LIKE 'J%' OR GNAME LIKE 'J%' OR " +
                            "BNAME LIKE 'K%' OR GNAME LIKE 'K%' OR " +
                            "BNAME LIKE 'L%' OR GNAME LIKE 'L%' " +
                            "ORDER BY BNAME, GNAME ASC;");
                    }
                case "5": {
                        return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE" +
                            "BNAME LIKE 'M%' OR GNAME LIKE 'M%' OR " +
                            "BNAME LIKE 'N%' OR GNAME LIKE 'N%' OR " +
                            "BNAME LIKE 'O%' OR GNAME LIKE 'O%' " +
                            "ORDER BY BNAME, GNAME ASC;");
                    }
                case "6": {
                        return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE" +
                            "BNAME LIKE 'P%' OR GNAME LIKE 'P%' OR " +
                            "BNAME LIKE 'Q%' OR GNAME LIKE 'Q%' OR " +
                            "BNAME LIKE 'R%' OR GNAME LIKE 'R%' " +
                            "ORDER BY BNAME, GNAME ASC;");
                    }
                case "7": {
                        return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE" +
                            "BNAME LIKE 'S%' OR GNAME LIKE 'S%' OR " +
                            "BNAME LIKE 'T%' OR GNAME LIKE 'T%' OR " +
                            "BNAME LIKE 'U%' OR GNAME LIKE 'U%' " +
                            "ORDER BY BNAME, GNAME ASC;");
                    }
                case "8": {
                        return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE" +
                            "BNAME LIKE 'V%' OR GNAME LIKE 'V%' OR " +
                            "BNAME LIKE 'W%' OR GNAME LIKE 'W%' OR " +
                            "BNAME LIKE 'X%' OR GNAME LIKE 'X%' " +
                            "ORDER BY BNAME, GNAME ASC;");
                    }
                case "9": {
                        return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE" +
                            "BNAME LIKE 'Y%' OR GNAME LIKE 'Y%' OR " +
                            "BNAME LIKE 'Z%' OR GNAME LIKE 'Z%' " +
                            "ORDER BY BNAME, GNAME ASC;");
                    }
            }
            return _database.QueryAsync<MEDICATIONS>("SELECT * FROM [MEDICATIONS] WHERE" +
                            "BNAME LIKE 'A%' OR GNAME LIKE 'A%' AND " +
                            "BNAME LIKE 'B%' OR GNAME LIKE 'B%' AND " +
                            "BNAME LIKE 'C%' OR GNAME LIKE 'C%' " +
                            "ORDER BY BNAME, GNAME ASC;");
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
