using SQLite;

namespace QuickMeds.Models {
    public class ControlClass {
        [PrimaryKey, AutoIncrement]
        public int ControlClassID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
    }
}
