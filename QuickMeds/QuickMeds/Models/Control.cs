using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace QuickMeds.Models {
    public class Control {
        [PrimaryKey, AutoIncrement]
        public int ControlID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
    }
}
