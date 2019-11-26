namespace QuickMeds.Models {
    public class MedicationList {
        public string MedicationName { get; set; }
        public string MedicationAKA { get; set; }
        public string MedicationConditions { get; set; }
        public string MedicationType { get; set; }
        public int MedicationBTFlag { get; set; }
        public string MedicationListItem { get { return string.Format("{0} ({1}) AKA {2} ({3})", MedicationName, MedicationType, MedicationAKA, MedicationType == "B" ? "G" : "B"); } }
    }
}
