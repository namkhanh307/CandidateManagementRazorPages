using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_Repositories
{
    public interface ICandidateProfileRepo
    {
        CandidateProfile? GetCandidateProfileById(string id);
        List<CandidateProfile> GetCandidateProfiles();
        (List<CandidateProfile> candidates, int totalItems, int totalPages) SearchCandidates(string? fullname, DateTime? birthday, int pageNumber, int pageSize);
        bool AddCandidateProfile(CandidateProfile candidateProfile);
        bool DeleteCandidateProfile(CandidateProfile candidateProfile);
        bool UpdateCandidateProfile(CandidateProfile candidateProfile);
    }
}
