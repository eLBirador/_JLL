using MvcCms.Areas.Admin.Services;
using MvcCms.Areas.Admin.ViewModels;
using MvcCms.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using MvcCms.Models;

namespace MvcCms.Controllers
{
    [RoutePrefix("")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IPostRepository _posts;
        private readonly int _pageSize = 2;

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly UserService _users;

        public HomeController() : this(new PostRepository()) { }

        public HomeController(IPostRepository postRepository)
        {
            _posts = postRepository;

            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
            _users = new UserService(ModelState, _userRepository, _roleRepository);
        }

        // GET: Default
        // root/
        [Route("")]
        public async Task<ActionResult> Index()
        {
            //var posts = await _posts.GetPageAsync(1, _pageSize);

            //ViewBag.PreviousPage = 0;
            //ViewBag.NextPage = (Decimal.Divide(_posts.CountPublished, _pageSize) > 1) ? 2 : -1;
            return RedirectToAction("register");
            //return View();
        }

        [HttpGet]
        [Route("register")]
        public async Task<ActionResult> Register()
        {
            //var posts = await _posts.GetPageAsync(1, _pageSize);
            //ViewBag.PreviousPage = 0;
            //ViewBag.NextPage = (Decimal.Divide(_posts.CountPublished, _pageSize) > 1) ? 2 : -1;
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "admin");
            }
            return View();
        }

        [Route("register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Register(UserViewModel model)
        {
            var user = new CmsUser { UserName = model.Email, Email = model.Email };

            var completed = await _users.CreateAsync(model);

            if (completed)
            {

                //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                //created user
                //log them in
                //var authManager = HttpContext.Current.GetOwinContext().Authentication;
                //var userIdentity - CmsUserManager.CreateIdentity()
                //    authManager.SignIn(userIdentity);
                //Response.Redirect("");

                return RedirectToAction("index",  "admin");
            }

            return View(model);
        }

        [HttpGet]
        [Route("sendtestemail")]
        public async Task<ActionResult> SendTestEmail()
        {
            // TODO : send Email Function

            MailMessage mailMessage = new MailMessage("cmd@yahaay.com", "gerald@yahaay.com");
            mailMessage.Subject = "Test Notification";
            mailMessage.Body = "Test Email Body";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);

            ViewBag.TestMessage = "My Test Message Here from ViewBag";
            TempData["TestMessage"] = "My Test Message From TempData";

            //var variableName = "Test Variable Value";
            //return Content(variableName);
            //return Content(variableName.ToLower() );

            return View();
        }

        [Route("page/{page:int}")]
        public async Task<ActionResult> Page(int page = 1)
        {
            if (page < 2)
            {
                return RedirectToAction("index");
            }

            var posts = await _posts.GetPageAsync(page, _pageSize);

            ViewBag.PreviousPage = page - 1;
            ViewBag.NextPage = (Decimal.Divide(_posts.CountPublished, _pageSize) > page) ? page + 1 : -1;

            return View("index", posts);
        }

        // root/posts/post-id
        [Route("posts/{postId}")]
        public async Task<ActionResult> Post(string postId)
        {
            var post = _posts.Get(postId);

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        // root/tags/tag-id
        [Route("tags/{tagId}")]
        public async Task<ActionResult> Tag(string tagId)
        {
            var posts = await _posts.GetPostsByTagAsync(tagId);

            if (!posts.Any())
            {
                return HttpNotFound();
            }

            ViewBag.Tag = tagId;

            return View(posts);
        }
    }
}