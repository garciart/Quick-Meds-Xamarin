using System;
using System.Collections.Generic;
using System.Text;

namespace QuickMeds.Models {
    public class Medication {
        public int MedicationID { get; set; }
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public int Action { get; set; }
        public string Description { get; set; }
        public int Control { get; set; }
        public bool BloodThinner { get; set; }
        public string SideEffects { get; set; }
        public string Interactions { get; set; }
        public string Warnings { get; set; }

    }
}
