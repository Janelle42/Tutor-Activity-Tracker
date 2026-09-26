using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor_Activity_Tracker.Models;

namespace Tutor_Activity_Tracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        // Connect to the database
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //fetch activities from the database
            var activities = _context.Activities
                .OrderByDescending(a => a.Date)
                .ToList();

            //Calculate totals
            ViewBag.TotalActivities = activities.Count;
            ViewBag.TotalStudents = activities.Sum(a => a.StudentsReached);
            ViewBag.TotalHours = activities.Sum(a => a.Duration);

            ViewBag.RecentActivities = activities.Take(5).ToList();

            var monthlyHours = new List<object>();

            if (activities.Any())
            {
                //The first  month && last month 
               
                var firstDate = new DateTime(
                    activities.Min(a => a.Date).Year,
                    activities.Min(a => a.Date).Month,
                    1);

                var lastDate = new DateTime(
                    activities.Max(a => a.Date).Year,
                    activities.Max(a => a.Date).Month,
                    1);

                // go through each month
                for (var date = firstDate; date <= lastDate; date = date.AddMonths(1))
                {
                    var hours = activities
                        .Where(a => a.Date.Year == date.Year &&
                                    a.Date.Month == date.Month)
                        .Sum(a => a.Duration);

                    monthlyHours.Add(new
                    {
                        Month = date.ToString("MMM"),
                        Hours = hours
                    });
                }
            }

            ViewBag.MonthlyHours = monthlyHours;

            return View();
        }
    }
}