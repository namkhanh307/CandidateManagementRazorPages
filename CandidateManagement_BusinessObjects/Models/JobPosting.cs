using System.ComponentModel.DataAnnotations;

namespace CandidateManagement_BusinessObjects.Models;

public partial class JobPosting
{
    public string PostingId { get; set; } = null!;
    [Required(ErrorMessage = "Title is required.")]
    public string JobPostingTitle { get; set; } = null!;
    [Required(ErrorMessage = "Description is required.")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "PostedDate is required.")]
    [DataType(DataType.Date)]
    public DateTime? PostedDate { get; set; }

    public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; } = new List<CandidateProfile>();
}
