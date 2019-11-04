using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace QuickMeds.Models {
    public class MEDICATIONS {
        [PrimaryKey, AutoIncrement]
        public int MEDID { get; set; }
        public string GNAME { get; set; }
        public string BNAME { get; set; }
        public int ACTION { get; set; }
        public int DEA { get; set; }
        public bool BTFLAG { get; set; }
        public string SIDE_EFFECTS { get; set; }
        public string INTERACTIONS { get; set; }
        public string WARNINGS { get; set; }
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
