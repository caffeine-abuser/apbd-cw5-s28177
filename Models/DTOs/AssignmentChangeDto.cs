public class AssignmentChangeDto(DateTime from, DateTime? to, string bedType, string ward)
{
    public DateTime From { get; set; } = from;
    public DateTime? To { get; set; } = to;
    public string BedType { get; set; } = bedType;
    public string Ward { get; set; } = ward;
}