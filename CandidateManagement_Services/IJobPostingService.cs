using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_Services
{
    public interface IJobPostingService
    {
        (List<JobPosting> Items, int TotalItems, int TotalPages) GetJobPostings(int pageNumber, int pageSize);

        List<JobPosting> GetJobPostings();
        JobPosting GetJobPostingById(string jobId);
        bool AddJobPosting(JobPosting jobPosting);
        bool DeleteJobPosting(JobPosting jobPosting);
        bool UpdateJobPosting(JobPosting jobPosting);
    }
}
