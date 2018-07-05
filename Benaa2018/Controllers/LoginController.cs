using Benaa2018.Data.Interfaces;
using Benaa2018.Helper;
using Benaa2018.Helper.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Benaa2018.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserMasterHelper _userMasterHelper;

        public LoginController(IUserMasterHelper userMasterHelper)
        {
            _userMasterHelper = userMasterHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel inputModel)
        {
            if (!await IsAuthentic(inputModel.UserName, inputModel.Password))
            {
                inputModel.Message = "Please Enter Correct UserName and Password";
                return View(inputModel);
            }
            // create claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, inputModel.UserId.ToString()),
                new Claim(ClaimTypes.Email, inputModel.UserId.ToString())
            };
            // create identity
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
            // create principal
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            // sign-in
            await HttpContext.SignInAsync(
                    scheme: "SBSSecurityScheme",
                    principal: principal,
                    properties: new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                    });
            return RedirectPermanent(@"/Home");
        }

        #region " Private "
        private async Task<bool> IsAuthentic(string userName, string password)
        {
            var userInfo = await _userMasterHelper.GetUserByUserName(userName);
            if(userInfo != null)
            {
                if (userInfo.Password == password.Trim())
                    return true;
                else
                {
                    return false;
                }                   
            }
            return false;
        }
        #endregion
    }
}