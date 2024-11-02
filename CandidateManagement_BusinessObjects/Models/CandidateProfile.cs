using System.ComponentModel.DataAnnotations;

namespace CandidateManagement_BusinessObjects.Models;

public partial class CandidateProfile
{
    public string CandidateId { get; set; } = null!;

    [Required(ErrorMessage = "Fullname is required.")]
    public string Fullname { get; set; } = null!;

    [Required(ErrorMessage = "Birthday is required.")]
    [DataType(DataType.Date)]
    public DateTime? Birthday { get; set; }
    [Required(ErrorMessage = "Profile Short Description is required.")]
    public string? ProfileShortDescription { get; set; }
    [Required(ErrorMessage = "ProfileUrl is required.")]
    public string? ProfileUrl { get; set; }

    public string? PostingId { get; set; }

    public virtual JobPosting? Posting { get; set; }
}
