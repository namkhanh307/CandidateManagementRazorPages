using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_GUI.Pages.LoginPages
{
    public class LoginModel : PageModel
    {
        private readonly IHRAccountService _hrAccountService;
        public LoginModel(IHRAccountService hrAccountService)
        {
            _hrAccountService = hrAccountService;
        }

        public void OnGet()
        {
        }

        public void OnPost()  
        {
            string? email = Request.Form["txtEmail"];
            string? password = Request.Form["txtPassword"];
            if(email != null && password != null)
            {
                Hraccount account = _hrAccountService.GetHraccountByEmail(email);
                if (account != null && account.Password!.Equals(password))
                {
                    string? roleId = account.MemberRole.ToString() ?? "";
                    string? emailUser = account.Email ?? "";
                    HttpContext.Session.SetString("RoleID", roleId);
                    HttpContext.Session.SetString("EmailUser", email);
                    Response.Redirect("/CandidateProfilePages");
                }
                else
                    Response.Redirect("/Error");
            }

        }
        public void OnGetLogout()
        {
            HttpContext.Session.SetString("RoleID", "");
            Response.Redirect("/LoginPages/Login");
        }
    }
}
