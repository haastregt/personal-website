using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using website.Models;

namespace website.Controllers
{
    public class HomeController : Controller
    {
        static List<ProjectSnippet> snippets = new List<ProjectSnippet>()
        {
            new ProjectSnippet {Id = 5,
                                Name = "Welcome",
                                Description = "A small introduction about me and this website.",
                                SkillTags = new List<string> {}
            },
            new ProjectSnippet {Id = 1,
                                Name = "Foundational Robotic Manipulation",
                                Description = "Engineered a framework that can translate natural language to actions for robot manipulation, using LLMs and diffusion policies.",
                                SkillTags = new List<string> {"ROS", "Python", "C++"}
            },
            new ProjectSnippet {Id = 3,
                                Name = "MPC for NASA's Astrobee",
                                Description = "Programmed and integrated a software package for a non-linear model predictive controller for NASA's Astrobee robots.",
                                SkillTags = new List<string> {"C++", "Python", "ROS"}
            },
            new ProjectSnippet {Id = 4,
                                Name = "Occlusion Aware Autonomous Driving",
                                Description = "Developed an algorithm allowing formally safe trajectories with an increase in velocities up to 20%.",
                                SkillTags = new List<string> {"C++", "Python", "Linux", "Docker"}
            },
			new ProjectSnippet {Id = 2,
								Name = "VR Simulator for Robot Teleoperation",
								Description = "Designed a VR simulator where a user can teleoperate a robotic arm.",
								SkillTags = new List<string> {"Linux", "C#", "Unity", "ROS"}
			},
            new ProjectSnippet {Id = 6,
                                Name = "Game Jam",
                                Description = "Created a fully functioning game by myself from scratch in 72 hours using Unity.",
                                SkillTags = new List<string> {"C#", "Unity"}
            },
            new ProjectSnippet {Id = 7,
                                Name = "Designing a Smart City",
                                Description = "Prototyping of a scaled version of a smart city using remote controlled vehicles and real life humans.",
                                SkillTags = new List<string> {"ROS", "Linux", "Python"}
            }
        };

        public IActionResult Index()
        {
            return View(snippets);
        }

        [HttpGet]
		public IActionResult ProjectContent([FromQuery] int itemId)
		{
            string partialViewName = "_ProjectContent"+itemId;
            ViewData["ItemId"] = itemId;
			return PartialView(partialViewName);
		}
	}
}
