﻿using System;
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
            Hraccount = hraccount;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private bool HraccountExists(string email)
        {
            return _hrAccountService.GetHraccountByEmail(email) != null;
        }
    }
}