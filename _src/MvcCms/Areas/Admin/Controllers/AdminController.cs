﻿using Microsoft.Owin.Security;
using MvcCms.Areas.Admin.ViewModels;
using MvcCms.Data;
using MvcCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace MvcCms.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IPostRepository _repository;
        private readonly IUserRepository _users;

        //public AdminController(IPostRepository repository, IUserRepository userRepository)
        //{
        //    _repository = repository;
        //    _users = userRepository;
        //}

        /*
        public AdminController()
            : this(new PostRepository(), new UserRepository()) { }

        public AdminController(PostRepository postRepository, UserRepository userRepository)
        {
           this.postRepository = postRepository;
           this.userRepository = userRepository;
        }
        */

        // GET: Admin/Index
        [Route("")]
        public async Task<ActionResult> Index()
        {
            if (!User.IsInRole("author"))
            {
                return View(await _repository.GetAllAsync());
            }

            var user = await GetLoggedInUser();
            var posts = await _repository.GetPostsByAuthorAsync(user.Id);

            return View(posts);
        }

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            /*
            if(ModelState.IsValid)
            {
                var user = await _users.GetLoginUserAsync(model.UserName, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "The user with the supplied credentials does not exist");
                }
                else
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = await _users.CreateIdentityAsync(user);

                    authManager.SignIn(
                        new AuthenticationProperties() { IsPersistent = model.RememberMe }, userIdentity);
                }
            }
            */
            return View( model );
            //return RedirectToAction("index");
        }

        [Route("logout")]
        public async Task<ActionResult> Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;

            authManager.SignOut();

            return RedirectToAction("login", "admin");
        }

        [AllowAnonymous]
        public async Task<PartialViewResult> AdminMenu()
        {
            var items = new List<AdminMenuItem>();

            if (User.Identity.IsAuthenticated)
            {
                items.Add(new AdminMenuItem
                {
                    Text = "Admin Home",
                    Action = "index",
                    RouteInfo = new { controller = "admin", area = "admin" }
                });

                if (User.IsInRole("admin"))
                {
                    items.Add(new AdminMenuItem
                    {
                        Text = "Users",
                        Action = "index",
                        RouteInfo = new { controller = "user", area = "admin" }
                    });
                }
                else
                {
                    items.Add(new AdminMenuItem
                    {
                        Text = "Profile",
                        Action = "edit",
                        RouteInfo = new { controller = "user", area = "admin", username = User.Identity.Name }
                    });
                }

                if (!User.IsInRole("author"))
                {
                    items.Add(new AdminMenuItem
                    {
                        Text = "Tags",
                        Action = "index",
                        RouteInfo = new { controller = "tag", area = "admin" }
                    });
                }

                items.Add(new AdminMenuItem
                {
                    Text = "Posts",
                    Action = "index",
                    RouteInfo = new { controller = "post", area = "admin" }
                });
            }

            return PartialView(items);
        }

        [AllowAnonymous]
        public async Task<PartialViewResult> AuthenticationLink()
        {
            var item = new AdminMenuItem
            {
                RouteInfo = new { controller = "admin", area = "admin" }
            };

            if (User.Identity.IsAuthenticated)
            {
                item.Text = "Logout";
                item.Action = "logout";
            }
            else
            {
                item.Text = "Login";
                item.Action = "login";
            }

            return PartialView("_menuLink", item);
        }

        private async Task<CmsUser> GetLoggedInUser()
        {
            return await _users.GetUserByNameAsync(User.Identity.Name);
        }

        private PostRepository postRepository;
        private UserRepository userRepository;

        //private bool _isDisposed;

        /*
        protected override void Dispose(bool disposing)
        {

            if (!_isDisposed)
            {
                _users.Dispose();
            }
            _isDisposed = true;

            base.Dispose(disposing);
        }
        */
    }
}