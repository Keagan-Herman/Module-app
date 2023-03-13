using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG_POE.Model;
using PROG_POE_ClassLib.Model;

namespace PROG_POE.Pages
{
    public class Add_ModuleModel : PageModel
    {
        [BindProperty]
        public StudentModules studentModules { get; set; }

        public UserManager<IdentityUser> UserManager { get; set; }
        public SignInManager<IdentityUser> SignInManager { get; }

        AuthDbContext _Context;

        public Add_ModuleModel(SignInManager<IdentityUser> signInManager, AuthDbContext databaseContext)
        {
            SignInManager = signInManager;
            _Context = databaseContext;
        }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (SignInManager.IsSignedIn(User))
                studentModules.UserName = User.Identity.Name;
            studentModules.SelfStudyHrsReq = studentModules.Num_Credits * 10 / studentModules.Semester_Weeks - studentModules.Class_Hours;
            studentModules.SelfStudyHrsRem = studentModules.SelfStudyHrsReq - studentModules.Hours_Studied;
            studentModules.Weeks = (studentModules.Date_Studied.Day + ((int)studentModules.Date_Studied.DayOfWeek)) / 7 + 1;
            {
                var info = studentModules;

                if (!ModelState.IsValid)
                {
                    return Page();
                }
                var result = _Context.Add(info);
                _Context.SaveChanges();
            }


            return RedirectToPage("Modules");
        }
    }
}
