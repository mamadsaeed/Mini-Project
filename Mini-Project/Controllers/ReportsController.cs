using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Project.Model;

namespace Mini_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ReportContext _context;

        public ReportsController(ReportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReport()
        {
            if (_context.Report == null)
            {
                return NotFound();
            }
            return await _context.Report.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Report>> PostReport(Report report)
        {
            _context.Report.Add(report);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetReport", new { id = report.Id }, report);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReport(int id)
        {
            if (_context.Report == null)
            {
                return NotFound();
            }
            var report = await _context.Report.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            _context.Report.Remove(report);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
