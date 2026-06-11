namespace apbd_cw5_s28177.Models;

public partial class Room
{
    public string Id { get; set; } = null!;

    public int WardId { get; set; }

    public bool HasTv { get; set; }

    public virtual ICollection<Bed> Beds { get; set; } = [];

    public virtual Ward Ward { get; set; } = null!;
}
