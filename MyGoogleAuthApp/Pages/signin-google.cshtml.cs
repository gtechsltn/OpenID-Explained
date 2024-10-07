using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyGoogleAuthApp.Pages
{
    public class SignInGoogleModel : PageModel
    {
        public IActionResult OnGet()
        {
            // The user will be redirected here after a successful login.
            var val=User.Identity.IsAuthenticated;

            return Page();
        }

        public async Task<IActionResult> OnPostLogout()
        {
            // Sign the user out
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("Google");

            return RedirectToPage("/Index"); // Redirect to the home page after logout
        }
    }
}
