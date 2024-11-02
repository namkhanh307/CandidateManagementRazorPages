using System.ComponentModel.DataAnnotations;

namespace CandidateManagement_BusinessObjects.Models;

public partial class Hraccount
{
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Password is required.")]

    public string? Password { get; set; }
    [Required(ErrorMessage = "Fullname is required.")]

    public string? FullName { get; set; }

    public int? MemberRole { get; set; }
}
