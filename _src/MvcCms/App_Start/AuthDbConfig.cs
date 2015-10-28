using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcCms.Data;
using MvcCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MvcCms.App_Start
{
    public class AuthDbConfig
    {
        public async static Task RegisterAdmin()
        {
            /*
            using (var posts = new PostRepository())
            {
                //var post = await posts.GetAllAsync();

                if( post == null)
                {
                    var defaultPost = new Post
                    {
                        Title = "Title"
                        //fields here
                    }

                   await posts.Create(defaultPost);
                }
            }
            */

            using (var users = new UserRepository())
            {
                var user = await users.GetUserByNameAsync("admin");

                if (user == null)
                {
                    var adminUser = new CmsUser
                    {
                        UserName = "admin",
                        Email = "admin@cms.com",
                        DisplayName = "admin@cms.com",
                        FirstName = "Application",
                        LastName = "Admin"
                    };

                    //sett a default password to AppAdmin
                    await users.CreateAsync(adminUser, "Passw0rd1234");
                    //adding AppAdmin to "admin" Role
                    await users.AddUserToRoleAsync(adminUser, "admin");
                }
            }

            //List All Possible Roles
            using (var roles = new RoleRepository())
            {
                if (await roles.GetRoleByNameAsync("admin") == null)
                {
                    await roles.CreateAsync(new IdentityRole("admin"));
                }

                if (await roles.GetRoleByNameAsync("editor") == null)
                {
                    await roles.CreateAsync(new IdentityRole("editor"));
                }

                if (await roles.GetRoleByNameAsync("author") == null)
                {
                    await roles.CreateAsync(new IdentityRole("author"));
                }

                if (await roles.GetRoleByNameAsync("client") == null)
                {
                    await roles.CreateAsync(new IdentityRole("client"));
                }

            }

        }
    }
}