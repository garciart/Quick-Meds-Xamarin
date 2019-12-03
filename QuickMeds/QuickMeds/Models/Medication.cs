using SQLite;

namespace QuickMeds.Models {
    public class Medication {
        [PrimaryKey, AutoIncrement]
        public int MedicationID { get; set; }
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public string ActionClass { get; set; }
        public int ControlClass { get; set; }
        public int BTFlag { get; set; }
        public string SideEffects { get; set; }
        public string Interactions { get; set; }
        public string Warnings { get; set; }
    }
}
