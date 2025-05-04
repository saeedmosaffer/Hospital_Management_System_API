using HospitalManagementSystemAPI.Models;
using HospitalManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("patient/{patientId}")]
        public IActionResult GetAppointmentsByPatient(int patientId)
        {
            var appointments = _appointmentService.GetAppointmentsByPatient(patientId);
            return Ok(appointments);
        }

        [HttpGet("doctor/{doctorId}")]
        public IActionResult GetAppointmentsByDoctor(int doctorId)
        {
            var appointments = _appointmentService.GetAppointmentsByDoctor(doctorId);
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointment(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }

        [HttpPost]
        public IActionResult CreateAppointment([FromBody] Appointment appointment)
        {
            _appointmentService.ScheduleAppointment(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpPut("{id}/cancel")]
        public IActionResult CancelAppointment(int id)
        {
            _appointmentService.CancelAppointment(id);
            return NoContent();
        }
    }
}
