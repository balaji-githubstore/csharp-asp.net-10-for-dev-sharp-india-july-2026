using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagementWebAppRazor.Pages
{
    public class LoginModel : PageModel
    {
        public async Task<IActionResult> OnPostLoginToSystem()
        {
            //in realtime - get username,password from the form and validate it and then set cookies 
            //set the cookies 
            // Step 2: Create Claims -A claim is information about the logged-in user.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Balaji"),
                new Claim(ClaimTypes.Email, "balaji@test.com"),
                new Claim(ClaimTypes.Role, "Admin")
            };
            // Step 3: Create Identity - This creates a ClaimsIdentity. (combines list of claims, authentication type ("Cookies"))
            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            // Step 4: Create Principal - A ClaimsPrincipal represents the current logged-in user.
            // Creates an authentication cookie
            // Stores the encrypted claims inside it
            // Sends it to the browser
            var principal = new ClaimsPrincipal(identity);

            // Step 5: Sign - It Creates the authentication cookie and sends it to the browser 
            // Creates an authentication cookie
            // Stores the encrypted claims inside it
            // Sends it to the browser
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal
                );

            // return Content("Login Successful. Cookie Created.");
            return RedirectToPage("Books/Index1");

        }


        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(
           CookieAuthenticationDefaults.AuthenticationScheme);

            return Content("Logged Out");
        }
    }


}
