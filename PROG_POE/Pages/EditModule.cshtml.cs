using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG_POE.Model;
using PROG_POE_ClassLib.Model;

namespace PROG_POE.Pages
{
    [Authorize]
    public class EditModuleModel : PageModel
    {
        public UserManager<IdentityUser> UserManager { get; set; }
        public SignInManager<IdentityUser> SignInManager { get; }
        [BindProperty]
        public StudentModules studentModules { get; set; }

        AuthDbContext _Context;

        public EditModuleModel(SignInManager<IdentityUser> signInManager, AuthDbContext databaseContext)
        {
            SignInManager = signInManager;
            _Context = databaseContext;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {

                var data = (from module in _Context.studentModules
                            where module.Student_Id == id
                            select module).SingleOrDefault();
                studentModules = data;
            }
        }

        public ActionResult OnPost()
        {
            var info = studentModules;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _Context.Entry(info).Property(x => x.Module_Code).IsModified = true;
            _Context.Entry(info).Property(x => x.Module_Name).IsModified = true;
            _Context.Entry(info).Property(x => x.Num_Credits).IsModified = true;
            _Context.Entry(info).Property(x => x.Class_Hours).IsModified = true;
            _Context.Entry(info).Property(x => x.Start_Date).IsModified = true;
            _Context.Entry(info).Property(x => x.Semester_Weeks).IsModified = true;
            _Context.Entry(info).Property(x => x.Date_Studied).IsModified = true;
            _Context.Entry(info).Property(x => x.Hours_Studied).IsModified = true;
            _Context.SaveChanges();
            return RedirectToPage("Modules");
        }
    }
}

