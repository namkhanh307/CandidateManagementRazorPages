using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO instance;
        public CandidateProfileDAO()
        {
            context = new CandidateManagementContext();
        }
        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfile? GetCandidateProfileById(string id)
        {
            return context.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }
        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.ToList();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? candidate = GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (candidate == null)
                {
                    context.CandidateProfiles.Add(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? existedCandidateProfile = GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (existedCandidateProfile != null)
                {
                    context.CandidateProfiles.Remove(candidateProfile);
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile? existedCandidateProfile = GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (existedCandidateProfile != null)
                {
                    context.Entry(existedCandidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    context.Entry(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
        public (List<CandidateProfile> candidates, int totalItems, int totalPages) SearchCandidates(string? fullname, DateTime? birthday, int pageNumber, int pageSize)
        {
            var candidates = context.CandidateProfiles.ToList();

            var query = candidates.AsQueryable();

            if (!string.IsNullOrWhiteSpace(fullname))
            {
                query = query.Where(c => c.Fullname.Contains(fullname)); 
            }

            if (birthday.HasValue)
            {
                query = query.Where(c => c.Birthday == birthday.Value.Date); 
            }

            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return (items, totalItems, totalPages);
        }


    }
}
