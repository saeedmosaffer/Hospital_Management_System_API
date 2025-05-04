using HospitalManagementSystemAPI.Models;
using HospitalManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HospitalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PrescriptionsController : ControllerBase
    {
        private readonly PrescriptionService _prescriptionService;
        private readonly BillingService _billingService;
        private readonly MedicationService _medicationService;

        public PrescriptionsController(PrescriptionService prescriptionService, BillingService billingService, MedicationService medicationService)
        {
            _prescriptionService = prescriptionService;
            _billingService = billingService;
            _medicationService = medicationService;
        }

        [HttpGet]
        public IActionResult GetPrescriptions()
        {
            var prescriptions = _prescriptionService.GetPrescriptions();
            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public IActionResult GetPrescription(int id)
        {
            var prescription = _prescriptionService.GetPrescriptionById(id);
            if (prescription == null)
                return NotFound();
            return Ok(prescription);
        }

        [HttpPost]
        public IActionResult CreatePrescription([FromBody] Prescription prescription)
        {
            _prescriptionService.IssuePrescription(prescription);

            if (prescription.PrescriptionMedications != null && prescription.PrescriptionMedications.Any())
            {
                var medicationId = prescription.PrescriptionMedications.First().MedicationId;
                var medication = _medicationService.GetMedicationById(medicationId);
                if (medication != null)
                {
                    var bill = new Bill
                    {
                        PrescriptionId = prescription.PrescriptionId,
                        Amount = medication.Price,
                        BillDate = DateTime.Now,
                        Status = BillStatus.Unpaid
                    };
                    _billingService.AddBill(bill);
                }
            }

            return CreatedAtAction(nameof(GetPrescription), new { id = prescription.PrescriptionId }, prescription);
        }
    }
}
