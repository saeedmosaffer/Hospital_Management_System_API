using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystemAPI.Models;
using HospitalManagementSystemAPI.Data;

namespace HospitalManagementSystemAPI.Services
{
    public class BillingService
    {
        private readonly HospitalContext _context;

        public BillingService(HospitalContext context)
        {
            _context = context;
        }

        public void AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
        }

        public List<Bill> GetBills()
        {
            return _context.Bills.ToList();
        }

        public Bill GetBillById(int id)
        {
            return _context.Bills.FirstOrDefault(b => b.BillId == id);
        }

        public void UpdateBill(Bill bill)
        {
            _context.Bills.Update(bill);
            _context.SaveChanges();
        }
    }
}
