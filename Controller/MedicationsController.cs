using HospitalManagementSystemAPI.Models;
using HospitalManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MedicationsController : ControllerBase
    {
        private readonly MedicationService _medicationService;

        public MedicationsController(MedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public IActionResult GetMedications()
        {
            var medications = _medicationService.GetMedications();
            return Ok(medications);
        }

        [HttpGet("{id}")]
        public IActionResult GetMedication(int id)
        {
            var medication = _medicationService.GetMedicationById(id);
            if (medication == null)
                return NotFound();
            return Ok(medication);
        }

        [HttpPost]
        public IActionResult CreateMedication([FromBody] Medication medication)
        {
            _medicationService.AddMedication(medication);
            return CreatedAtAction(nameof(GetMedication), new { id = medication.MedicationId }, medication);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMedication(int id, [FromBody] Medication updatedMedication)
        {
            var medication = _medicationService.GetMedicationById(id);
            if (medication == null)
                return NotFound();

            medication.Name = updatedMedication.Name;
            medication.Quantity = updatedMedication.Quantity;
            medication.Price = updatedMedication.Price;

            _medicationService.UpdateMedication(medication);
            return NoContent();
        }
    }
}
