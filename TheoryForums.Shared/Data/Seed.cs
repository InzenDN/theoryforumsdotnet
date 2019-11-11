﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using TheoryForums.Shared.Models;
using TheorySlugify;

namespace TheoryForums.Shared.Data
{
    public static class Seed
    {
        public static void SeedData(DataContext context, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            if (!roleManager.Roles.Any())
            {
                List<Role> roles = new List<Role>()
                {
                    new Role() { Name = "Administrator"},
                    new Role() { Name = "Moderator"},
                    new Role() { Name = "Member"},
                    new Role() { Name = "Guest"}
                };

                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role);
                }
            }

            if (!userManager.Users.Any())
            {
                User newAdmin = new User()
                {
                    DisplayName = "Bob the Magnificent",
                    UserName = "Bob",
                    Email = "Bob@bob.com",
                    JoinDate = DateTime.Now
                };

                userManager.CreateAsync(newAdmin, "password");
                userManager.AddToRolesAsync(newAdmin, new string[] { "Member", "Moderator", "Administrator" });
            }

            if (context.Forums.Any())
                return;

            Forum[] forums = new Forum[]
            {
                new Forum() { Title = "My Digital Life", Description="" },
                new Forum() { Title = "Software And Modifications", Description="" },
                new Forum() { Title = "Gadget And Hardware Life", Description="" }
            };

            context.Forums.AddRange(forums);
            context.SaveChanges();

            Subforum[] subforums = new Subforum[]
            {
                new Subforum() { Title = "Announcements", Description = "", Icon = "bullhorn", ForumFK = 1},
                new Subforum() { Title = "Giveaways and Contests", Description = "", Icon = "gift", ForumFK = 1},
                new Subforum() { Title = "BIOS Mods", Description = "", Icon = "magic", ForumFK = 2},
                new Subforum() { Title = "MDL Projects and Applications", Description = "", Icon = "cogs", ForumFK = 2},
                new Subforum() { Title = "Application Software", Description = "", Icon = "link", ForumFK = 2},
                new Subforum() { Title = "PC Hardware", Description = "", Icon = "wrench", ForumFK = 3},
                new Subforum() { Title = "Mobile and Portable", Description = "", Icon = "laptop", ForumFK = 3},
                new Subforum() { Title = "Gaming", Description = "", Icon = "gamepad", ForumFK = 3}
            };

            foreach (var item in subforums)
            {
                context.Subforums.Add(item);
                context.SaveChanges();
            }

            int adminId = userManager.FindByNameAsync("Bob").Result.Id;

            Thread[] threads = new Thread[]
            {
                new Thread() { Title = "Smilies for our members and guests", Content = "You need to login to view this posts content.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 1, AuthorId = adminId },
                new Thread() { Title = "Emsisoft Anti-Malware 25 x 1-Year/1PC Giveaway#2", Content = "Emsisoft is an award-winning security that protects your devices, your data and your identity without slowing you down.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 2, AuthorId = adminId },
                new Thread() { Title = "Award & AMI Bios mod requests", Content = "You need to login to view this posts content.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 3, AuthorId = adminId },
                new Thread() { Title = "Award & AMI Bios mod requests 2", Content = "You need to login to view this posts content.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 3, AuthorId = adminId },
                new Thread() { Title = "Award & AMI Bios mod requests 3", Content = "You need to login to view this posts content.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 3, AuthorId = adminId },
                new Thread() { Title = "MSMG ToolKit", Content = "You need to login to view this posts content.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 4, AuthorId = adminId },
                new Thread() { Title = "Use Office Tool to download, install, manage and activate Office 2016, 2019 and 365", Content = "You need to login to view this posts content.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 5, AuthorId = adminId },
                new Thread() { Title = "Marvell Controller Card Issues", Content = "I have an IOCrest card (I/O Crest 8 Port SATA III PCIe 2.0 x2 Non RAID Controller Card) and it's recently started dropping the drives attached to it when I copy data to or from one of the drives connected to it (non-RAID).", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 6, AuthorId = adminId },
                new Thread() { Title = "Huawei and Trump Ban", Content = "I have the Huawei Y6 Pro 2019 and Huawei Media pad Tablet. Both are good.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 7, AuthorId = adminId },
                new Thread() { Title = "Games will not start in windows 10", Content = "I can install hidden object games. that worked in windows 7,8 but not 10. no errors come up", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, SubforumFK = 8, AuthorId = adminId }
            };

            foreach (var thread in threads)
            {
                context.Threads.Add(thread);
                context.SaveChanges();
            }

            Post[] posts = new Post[]
            {
                new Post() { Content = "Can someone please reupload these? Thanks!", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, ThreadFK = 1, AuthorId = adminId },
                new Post() { Content = "I'm currently using Kaspersky on my another computer and i'd love to use EAM on my new PC.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, ThreadFK = 2, AuthorId = adminId },
                new Post() { Content = "I made mine with andyp's ami bios tool and it works!! (default 1.29 settings).", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, ThreadFK = 3, AuthorId = adminId },
                new Post() { Content = "Don't run! Says the OS architecture is x86 but it is x64!!!", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, ThreadFK = 6, AuthorId = adminId },
                new Post() { Content = "Only Office Tool Lite can install Office 2016 Volume Edition when you are using Install Mode: Office Tool Lite, not Office Deployment Tool, this is right.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, ThreadFK = 7, AuthorId = adminId },
                new Post() { Content = "PCI Express x2 interface max 4 Sata III ports, guess thats the problem.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, ThreadFK = 8, AuthorId = adminId },
                new Post() { Content = "The products that are sold already are not affected. You still will get updates. Google said they anyway want to do business with Huawei.", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, ThreadFK = 9, AuthorId = adminId },
                new Post() { Content = "I assume you tried compatibility mode I run games from 2006-07 and set them to run as administrator I have played old hidden objects games on windows 10 pro 64bit", CreatedOn = DateTime.Now, Edited = false, LastEditDate = DateTime.MinValue, ThreadFK = 10, AuthorId = adminId },
            };

            foreach (var post in posts)
            {
                context.Posts.Add(post);
                context.SaveChanges();
            }
        }
    }
}
