using DesignPatterns.Strategy.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            Settings settings = new();
            var claim = User.Claims.Where(x => x.Type == Settings.ClaimDatabaseType).FirstOrDefault();
            if (claim != null)
            {
                settings.DatabaseType = (EDatabaseType)int.Parse(claim.Value);
            }
            else
            {
                settings.DatabaseType = settings.GetDefaultDatabaseType;
            }

            return View(settings);
        }

        public async Task<IActionResult> ChangeDatabase(EDatabaseType databaseType)
        {
            var newClaim = new Claim(Settings.ClaimDatabaseType, ((int)databaseType).ToString());

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var claims = await _userManager.GetClaimsAsync(user);
            var databaseClaim = claims.Where(x => x.Type == Settings.ClaimDatabaseType).FirstOrDefault();
            if (databaseClaim != null)
            {
                await _userManager.ReplaceClaimAsync(user, databaseClaim, newClaim);
            }
            else
            {
                await _userManager.AddClaimAsync(user, newClaim);
            }

            await _signInManager.SignOutAsync();

            var authenticateResult = await HttpContext.AuthenticateAsync();
            await _signInManager.SignInAsync(user, authenticateResult.Properties);
            return RedirectToAction(nameof(Index));
        }
    }
}
