using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_DAO;
using CandidateManagement_Services;

namespace CandidateManagement_GUI.Pages.HrAccountPages
{
    public class EditModel : PageModel
    {
        private readonly IHRAccountService _hrAccountService;

        public EditModel(IHRAccountService hRAccountService)
        {
            _hrAccountService = hRAccountService;
        }
        [BindProperty]
        public Hraccount Hraccount { get; set; } = default!;
        string? EmailUser => HttpContext.Session.GetString("EmailUser") ?? "";

        public IActionResult OnGet()
        {
            if (string.IsNullOrWhiteSpace(EmailUser))
            {
                return NotFound();
            }

            Hraccount = _hrAccountService.GetHraccountByEmail(EmailUser);
            if (Hraccount == null)
            {
                return NotFound();
            }

            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool updateSuccess = _hrAccountService.UpdateHrAccount(Hraccount.Email, Hraccount.FullName, Hraccount.Password);

            if (!updateSuccess)
            {
                if (!HraccountExists(Hraccount.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw new DbUpdateConcurrencyException();
                }
            }

            return RedirectToPage("/CandidateProfilePages/Index");
        }

        private bool HraccountExists(string email)
        {
            return _hrAccountService.GetHraccountByEmail(email) != null;
        }
    }
}
