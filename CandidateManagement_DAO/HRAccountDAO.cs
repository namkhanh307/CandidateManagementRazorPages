using CandidateManagement_BusinessObjects.Models;

namespace CandidateManagement_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;
        private static HRAccountDAO instance = null;
        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }
        public HRAccountDAO()
        {
            context = new CandidateManagementContext();
        }
        public Hraccount? GetHraccountByEmail(string email)
        {
            return context.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
        }
        public IEnumerable<Hraccount> GetHraccounts()
        {
            return context.Hraccounts.ToList();
        }
        public bool UpdateHrAccount(string email, string fullName, string password)
        {
            bool isSuccess = false;
            Hraccount? hraccount = GetHraccountByEmail(email);
            try
            {
                if (hraccount != null)
                {
                    hraccount.FullName = fullName;
                    hraccount.Password = password;
                    context.Entry(hraccount).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    context.Entry(hraccount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
    }
}
