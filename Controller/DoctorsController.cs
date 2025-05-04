using HospitalManagementSystemAPI.Models;
using HospitalManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorsController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var doctors = _doctorService.GetDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if (doctor == null)
                return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult CreateDoctor([FromBody] Doctor doctor)
        {
            _doctorService.AddDoctor(doctor);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.DoctorId }, doctor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, [FromBody] Doctor updatedDoctor)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if (doctor == null)
                return NotFound();

            doctor.Name = updatedDoctor.Name;
            doctor.Age = updatedDoctor.Age;
            doctor.Gender = updatedDoctor.Gender;
            doctor.ContactNumber = updatedDoctor.ContactNumber;
            doctor.Email = updatedDoctor.Email;
            doctor.Specialty = updatedDoctor.Specialty;

            _doctorService.UpdateDoctor(doctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            _doctorService.DeleteDoctor(id);
            return NoContent();
        }
    }
}
