﻿using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_DAO;

namespace CandidateManagement_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateProfile);

        public CandidateProfile? GetCandidateProfileById(string id) => CandidateProfileDAO.Instance.GetCandidateProfileById(id);

        public List<CandidateProfile> GetCandidateProfiles() => CandidateProfileDAO.Instance.GetCandidateProfiles();

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);

        public (List<CandidateProfile> candidates, int totalItems, int totalPages) SearchCandidates(string? fullname, DateTime? birthday, int pageNumber, int pageSize) => CandidateProfileDAO.Instance.SearchCandidates(fullname, birthday, pageNumber, pageSize);
    }
}
