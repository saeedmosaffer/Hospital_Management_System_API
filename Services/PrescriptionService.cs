using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystemAPI.Models;
using HospitalManagementSystemAPI.Data;

namespace HospitalManagementSystemAPI.Services
{
    public class PrescriptionService
    {
        private readonly HospitalContext _context;

        public PrescriptionService(HospitalContext context)
        {
            _context = context;
        }

        public void IssuePrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
        }

        public List<Prescription> GetPrescriptions()
        {
            return _context.Prescriptions.ToList();
        }

        public Prescription GetPrescriptionById(int id)
        {
            return _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
        }
    }
}
