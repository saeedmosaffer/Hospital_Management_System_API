using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemAPI.Models
{
    public class PrescriptionMedication
    {
        // Composite key: PrescriptionId + MedicationId
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

        public string Dosage { get; set; } // e.g., "2 pills daily"
    }
}
