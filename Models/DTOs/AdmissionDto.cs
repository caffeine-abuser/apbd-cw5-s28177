namespace apbd_cw5_s28177.Models.DTOs;
using apbd_cw5_s28177.Models;

public class AdmissionDto(Admission admission)
{
    public int Id { get; set; } = admission.Id;
    public DateTime AdmissionDate { get; set; } = admission.AdmissionDate;
    public DateTime? DischargeDate { get; set; } = admission.DischargeDate;
    public WardDto Ward { get; set; } = new WardDto(admission.Ward);
}