namespace apbd_cw5_s28177.Models.DTOs;
using apbd_cw5_s28177.Models;

public class BedAssignmentDto(BedAssignment bedAssignment)
{
    public int Id { get; set; } = bedAssignment.Id;
    public DateTime From { get; set; } = bedAssignment.From;
    public DateTime? To { get; set; } = bedAssignment.To;
    public BedDto Bed { get; set; } = new BedDto(bedAssignment.Bed);
}