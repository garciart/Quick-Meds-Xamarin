using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace QuickMeds.Models {
    public class MEDICATIONS {
        [PrimaryKey, AutoIncrement]
        public int Medication_ID { get; set; }
        public string Generic_Name { get; set; }
        public string Brand_Name { get; set; }
        public int Action { get; set; }
        public int DEA_Flag { get; set; }
        public bool BT_Flag { get; set; }
        public string Side_Effects { get; set; }
        public string Interactions { get; set; }
        public string Warnings { get; set; }
        /*
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
        */
    }
}
