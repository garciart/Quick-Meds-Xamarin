using SQLite;

namespace QuickMeds.Models {
    public class ActionClass {
        [PrimaryKey, AutoIncrement]
        public int ActionClassID { get; set; }
        public string Name { get; set; }
    }
}
