using apbd_cw5_s28177.Models;
using apbd_cw5_s28177.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw5_s28177.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController(HospitalContext ctx, ILogger<PatientsController> logger) : Controller
{
    private readonly ILogger<PatientsController> _logger = logger;
    private readonly HospitalContext db = ctx;

    [HttpGet]
    public async Task<IActionResult> GetPatient([FromQuery] string? search) {
        if (string.IsNullOrWhiteSpace(search))
        {
            // return everyone
            var all = await db.Patients.ToListAsync();

            if (!all.Any()) return NotFound("No patients in the database. Like, at all. ...hm?");
            
            return Ok(all.Select(p => new FullPatientDto(p)).ToList());
        }

        // return whatever the search term asks us for
        var matching = db.Patients.Where(p =>
               EF.Functions.Like(p.FirstName, $"%{search}%")
            || EF.Functions.Like(p.LastName,  $"%{search}%")
        );

        if (!matching.Any()) return NotFound("No patients found for this search term.");

        return Ok(await matching.Select(p => new FullPatientDto(p)).ToListAsync());
    }

    [HttpPost("{pesel}/bedassignments")]
    public async Task<IActionResult> SetBedAssignment(string pesel, [FromBody] AssignmentChangeDto request)
    {
        var patient = await db.Patients.FirstOrDefaultAsync(p => p.Pesel == pesel);

        // #1: does the patient even exist?
        if (patient is null)
            return BadRequest("No patient found with this PESEL.");

        // #2: are the dates sane?
        if (request.From > request.To)
            return BadRequest("Incorrect times - they seem out of order.");

        // #3: is there a bed available in this ward, during those times?
        var bed = await db.Beds.Where(b => b.Room.Ward.Name == request.Ward)
            .Where(b => !b.BedAssignments.Any(
                ba => (ba.To == null || ba.To > request.From)
                      && (request.To == null || ba.From < request.To)
            ))
            .FirstOrDefaultAsync();

        if (bed is null) return NotFound("No free beds are available in this period. Try another ward or date.");

        var assignment = new BedAssignment()
        {
            PatientPeselNavigation = patient,
            Bed = bed,
            From = request.From,
            To = request.To
        };

        patient.BedAssignments.Add(assignment);

        await db.SaveChangesAsync();
        return Ok();
    }
}
