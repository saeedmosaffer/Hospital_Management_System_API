using HospitalManagementSystemAPI.Models;
using HospitalManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientsController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var patients = _patientService.GetPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            _patientService.AddPatient(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Patient updatedPatient)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
                return NotFound();

            // Update fields
            patient.Name = updatedPatient.Name;
            patient.Age = updatedPatient.Age;
            patient.Gender = updatedPatient.Gender;
            patient.ContactNumber = updatedPatient.ContactNumber;
            patient.Address = updatedPatient.Address;

            _patientService.UpdatePatient(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            _patientService.DeletePatient(id);
            return NoContent();
        }
    }
}
