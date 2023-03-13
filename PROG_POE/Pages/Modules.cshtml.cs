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
    public class ModulesModel : PageModel
    {
        public UserManager<IdentityUser> UserManager { get; set; }
        public SignInManager<IdentityUser> SignInManager { get; }

        AuthDbContext _Context;

        public ModulesModel(SignInManager<IdentityUser> signInManager, AuthDbContext context)
        {
            SignInManager = signInManager;
            _Context = context;
        }

        public List<StudentModules> studentModules { get; set; }
        public void OnGet()
        {
            var data = (from moduleList in _Context.studentModules
                        select moduleList).ToList();

            studentModules = data;
        }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {

                var data = (from module in _Context.studentModules
                            where module.Student_Id == id
                            select module).SingleOrDefault();

                _Context.Remove(data);
                _Context.SaveChanges();
            }
            return RedirectToPage("Modules");
        }
    }
    
    
}
