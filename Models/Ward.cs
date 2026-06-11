namespace apbd_cw5_s28177.Models;

public partial class Ward
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Admission> Admissions { get; set; } = [];

    public virtual ICollection<Room> Rooms { get; set; } = [];
}
