using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_DAO;
using CandidateManagement_Repositories;

namespace CandidateManagement_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo candidateProfileRepo;
        public CandidateProfileService()
        {
            candidateProfileRepo = new CandidateProfileRepo();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => candidateProfileRepo.AddCandidateProfile(candidateProfile);
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile) => candidateProfileRepo.DeleteCandidateProfile(candidateProfile);
        public CandidateProfile? GetCandidateProfileById(string id) => candidateProfileRepo.GetCandidateProfileById(id);
        public List<CandidateProfile> GetCandidateProfiles() => candidateProfileRepo.GetCandidateProfiles();

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => candidateProfileRepo.UpdateCandidateProfile(candidateProfile);

        (List<CandidateProfile> candidates, int totalItems, int totalPages) ICandidateProfileService.SearchCandidates(string? fullname, DateTime? birthday, int pageNumber, int pageSize) => candidateProfileRepo.SearchCandidates(fullname, birthday, pageNumber, pageSize);
    }
}
