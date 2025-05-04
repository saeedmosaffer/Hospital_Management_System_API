using HospitalManagementSystemAPI.Models;
using HospitalManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BillsController : ControllerBase
    {
        private readonly BillingService _billingService;

        public BillsController(BillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet]
        public IActionResult GetBills()
        {
            var bills = _billingService.GetBills();
            return Ok(bills);
        }

        [HttpGet("{id}")]
        public IActionResult GetBill(int id)
        {
            var bill = _billingService.GetBillById(id);
            if (bill == null)
                return NotFound();
            return Ok(bill);
        }

        [HttpPut("{id}/pay")]
        public IActionResult PayBill(int id)
        {
            var bill = _billingService.GetBillById(id);
            if (bill == null)
                return NotFound();

            bill.Status = BillStatus.Paid;
            _billingService.UpdateBill(bill);
            return NoContent();
        }
    }
}
