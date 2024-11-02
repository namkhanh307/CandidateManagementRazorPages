using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Matching;

namespace CandidateManagement_GUI.Pages.CandidateProfilePages
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;

        public IndexModel(ICandidateProfileService candidateProfileService)
        {
            _candidateProfileService = candidateProfileService;
        }

        public IList<CandidateProfile> CandidateProfile { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public void OnGet(string fullname, DateTime? birthday, int pageNumber = 1, int pageSize = 3)
        {
            var (items, totalItems, totalPages) = _candidateProfileService.SearchCandidates(fullname, birthday, pageNumber, pageSize);

            CandidateProfile = items;
            CurrentPage = pageNumber;
            TotalPages = totalPages;
        }
    }
}
