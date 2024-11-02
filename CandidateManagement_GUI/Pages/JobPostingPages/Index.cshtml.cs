using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_GUI.Pages.JobPostingPages
{
    public class IndexModel : PageModel
    {
        private readonly IJobPostingService _jobPostingService;

        public IndexModel(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        public IList<JobPosting> JobPosting { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public void OnGet(int pageNumber = 1, int pageSize = 3)
        {
            var (items, totalItems, totalPages) = _jobPostingService.GetJobPostings(pageNumber, pageSize);

            JobPosting = items;
            CurrentPage = pageNumber;
            TotalPages = totalPages;
        }
    }
}
