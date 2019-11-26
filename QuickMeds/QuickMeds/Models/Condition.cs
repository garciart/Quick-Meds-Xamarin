using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace QuickMeds.Models {
    public class Condition {
        [PrimaryKey, AutoIncrement]
        public int Condition_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
