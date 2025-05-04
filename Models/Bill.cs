using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemAPI.Models
{
    public enum BillStatus
    {
        Paid,
        Unpaid
    }
    public class Bill
    {
        public int BillId { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillDate { get; set; }
        public BillStatus Status { get; set; }
    }
}
