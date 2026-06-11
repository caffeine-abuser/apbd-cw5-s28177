namespace apbd_cw5_s28177.Models.DTOs;
using apbd_cw5_s28177.Models;

public class WardDto(Ward ward)
{
    public int Id { get; set; } = ward.Id;
    public string Name { get; set; } = ward.Name;
    public string Description { get; set; } = ward.Description;
}