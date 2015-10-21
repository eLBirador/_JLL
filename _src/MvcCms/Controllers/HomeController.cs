using MvcCms.Areas.Admin.Services;
using MvcCms.Areas.Admin.ViewModels;
using MvcCms.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcCms.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly UserService _users;

        public HomeController()
        {
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
            _users = new UserService(ModelState, _userRepository, _roleRepository);
        }

        // GET: Home
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("register");
        }

        // GET: Home
        public ActionResult ServerTest()
        {
            return View();
            //return RedirectToAction("register");
        }

        // GET: Home/register
        [Route("register")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Register()
        {
            var model = new UserViewModel();
            model.LoadUserRoles(await _roleRepository.GetAllRolesAsync());

            return View(model);
        }

        [Route("register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Register(UserViewModel model)
        {
            var completed = await _users.CreateAsync(model);

            if (completed)
            {
                return RedirectToAction("index");
            }

            return View(model);
        }
    }
}