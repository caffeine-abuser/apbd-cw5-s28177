namespace apbd_cw5_s28177.Models.DTOs;
using apbd_cw5_s28177.Models;

public class BedTypeDto(BedType bedType)
{
    public int Id { get; set; } = bedType.Id;
    public string Name { get; set; } = bedType.Name;
    public string Description { get; set; } = bedType.Description;
}