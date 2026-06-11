namespace apbd_cw5_s28177.Models.DTOs;
using apbd_cw5_s28177.Models;

public class RoomDto(Room room)
{
    public string Id { get; set; } = room.Id;
    public bool HasTv { get; set; } = room.HasTv;
    public WardDto Ward { get; set; } = new WardDto(room.Ward);
}