namespace apbd_cw5_s28177.Models.DTOs;
public class FullPatientDto(Patient patient)
{
    public string Pesel { get; set; } = patient.Pesel;
    public string FirstName { get; set; } = patient.FirstName;
    public string LastName { get; set; } = patient.LastName;
    public int Age { get; set; } = patient.Age;
    public bool Sex { get; set; } = patient.Sex;
    public ICollection<AdmissionDto> Admissions { get; set; } = [.. patient.Admissions.Select(a => new AdmissionDto(a))];
    public ICollection<BedAssignmentDto> BedAssignments { get; set; } = [.. patient.BedAssignments.Select(b => new BedAssignmentDto(b))];
}

