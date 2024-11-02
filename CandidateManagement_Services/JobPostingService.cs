using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Repositories;

namespace CandidateManagement_Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo _jobPostingRepo;
        public JobPostingService()
        {
            _jobPostingRepo = new JobPostingRepo();
        }

        public bool AddJobPosting(JobPosting jobPosting) => _jobPostingRepo.AddJobPosting(jobPosting);

        public bool DeleteJobPosting(JobPosting jobPosting) => _jobPostingRepo.DeleteJobPosting(jobPosting);

        public JobPosting GetJobPostingById(string jobId) => _jobPostingRepo.GetJobPostingById(jobId);

        public List<JobPosting> GetJobPostings() => _jobPostingRepo.GetJobPostings();

        public (List<JobPosting> Items, int TotalItems, int TotalPages) GetJobPostings(int pageNumber, int pageSize)
        {
            var allJobPostings = _jobPostingRepo.GetJobPostings();
            var totalItems = allJobPostings.Count();

            var pagedProfiles = allJobPostings
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return (pagedProfiles, totalItems, totalPages);
        }

        public bool UpdateJobPosting(JobPosting jobPosting) => _jobPostingRepo.UpdateJobPosting(jobPosting);
    }
}
