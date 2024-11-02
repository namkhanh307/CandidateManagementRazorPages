using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObjects.Models;
using CandidateManagement_DAO;
using CandidateManagement_Services;

namespace CandidateManagement_GUI.Pages.HrAccountPages
{
    public class DetailsModel : PageModel
    {
        private readonly IHRAccountService _hrAccountService;

        public DetailsModel(IHRAccountService hRAccountService)
        {
            _hrAccountService = hRAccountService;
        }

        public Hraccount Hraccount { get; set; } = default!;

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string? email = HttpContext.Session.GetString("EmailUser") ?? "";

            var hraccount = _hrAccountService.GetHraccountByEmail(email);
            if (hraccount == null)
            {
                return NotFound();
            }
            else
            {
                Hraccount = hraccount;
            }
            return Page();
        }
    }
}
