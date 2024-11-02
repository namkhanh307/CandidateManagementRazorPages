using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_DAO;

namespace CandidateManagement_Repositories
{
    public interface IHRAccountRepo
    {

        Hraccount GetHraccountByEmail(string email);
        public IEnumerable<Hraccount> GetHraccounts();
        bool UpdateHrAccount(string email, string fullName, string password);

    }
}
