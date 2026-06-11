namespace apbd_cw5_s28177.Models;

public partial class Patient
{
    public string Pesel { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public bool Sex { get; set; }

    public virtual ICollection<Admission> Admissions { get; set; } = [];

    public virtual ICollection<BedAssignment> BedAssignments { get; set; } = [];
}
