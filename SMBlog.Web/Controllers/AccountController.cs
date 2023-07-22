
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMBlog.Models.Account;
using SMBlog.Services;

namespace SMBlog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUserIdentity> _userManager;
        private readonly SignInManager<ApplicationUserIdentity> _signInManager;

        public AccountController(ITokenService tokenService, 
            UserManager<ApplicationUserIdentity> userManager, 
            SignInManager<ApplicationUserIdentity> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> Register(ApplicationUserCreate applicationUserCreate)
        {
            var applicationUserIdentity= new ApplicationUserIdentity{
                UserName = applicationUserCreate.UserName,
                Email  = applicationUserCreate.Email,
                FullName = applicationUserCreate.FullName
            };

            var result = await _userManager.CreateAsync(applicationUserIdentity, applicationUserCreate.Password);

            if (result.Succeeded)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    ApplicationUserId = applicationUserIdentity.ApplicationUserId,
                    UserName = applicationUserIdentity.UserName,
                    Email = applicationUserIdentity.Email,
                    FullName = applicationUserIdentity.FullName,
                    Token = _tokenService.CreateToken(applicationUserIdentity)
                };
                return Ok(applicationUser);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUser>> Login(ApplicationUserLogin applicationUserLogin)
        {
            var applicationUserIdentity = await _userManager.FindByNameAsync(applicationUserLogin.UserName);
            if (applicationUserIdentity != null)
            {
                var result = _signInManager.CheckPasswordSignInAsync(applicationUserIdentity, applicationUserLogin.Password, false );

                if (result.IsCompletedSuccessfully)
                {
                    ApplicationUser applicationUser = new ApplicationUser()
                    {
                        ApplicationUserId = applicationUserIdentity.ApplicationUserId,
                        UserName = applicationUserIdentity.UserName,
                        Email = applicationUserIdentity.Email,
                        FullName = applicationUserIdentity.FullName,
                        Token = _tokenService.CreateToken(applicationUserIdentity)
                    };
                    return Ok(applicationUser);
                }
            }

            return BadRequest("Invalid login attempt.");
        }
    }
}
