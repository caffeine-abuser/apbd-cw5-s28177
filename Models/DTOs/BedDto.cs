namespace apbd_cw5_s28177.Models.DTOs;
using apbd_cw5_s28177.Models;

public class BedDto(Bed bed)
{
    public int Id { get; set; } = bed.Id;
    public BedTypeDto BedType { get; set; } = new BedTypeDto(bed.BedType);
    public RoomDto Room { get; set; } = new RoomDto(bed.Room);
}