using CaloriesCount.DAL;
using CaloriesCount.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaloriesCount.Controllers
{
    public class HomeController : BaseController
    {
        private CaloriesCountContext db = new CaloriesCountContext();
        public ActionResult SplashScreen()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Message message)
        {
            if (ModelState.IsValid)
            {
                // Get the current date.
                message.MessageDate = DateTime.Now.Date;

                // Add to database.
                db.Messages.Add(message);
                db.SaveChanges();

                // Create temp data,
                TempData["AlertMessage"] = "Message send successfully!";

                // Redurect to the index action.
                return RedirectToAction("Contact");

            }
            return View(message);
        }

        public ActionResult Learn()
        {
            return View();
        }

        public ActionResult Podcasts()
        {
            // Store the audio files in a List
            List<Podcast> podcasts = new List<Podcast>();

            // Loop through all the files in the directory
            foreach(var file in Directory.GetFiles(Server.MapPath(Constants.PodcastPath)))
            {
                // Get the filename without extension
                string name = Path.GetFileNameWithoutExtension(file);

                // replace the underscores in the file name with a space
                name = name.Remove(0, 17).Replace("_", " ");

                // Add a new podcast to the podcasts array
                podcasts.Add(new Podcast
                {
                    Name = name,
                    FilePath = Constants.PodcastPath + Path.GetFileName(file)
                });
            }

            // order the podcasts by name
            podcasts = podcasts.OrderBy(x => x.Name).ToList();

            // Pass the podcasts to the view
            return View(podcasts);
        }
    }
}