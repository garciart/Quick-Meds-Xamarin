using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace QuickMeds.Models {
    public class Action {
        [PrimaryKey, AutoIncrement]
        public int ActionID { get; set; }
        public string Name { get; set; }
    }
}
