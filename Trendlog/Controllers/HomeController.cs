using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trendlog.Models;

namespace Trendlog.Controllers {
    public class HomeController : Controller {
        private readonly TrendlogContext _context;

        public HomeController(TrendlogContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            MainPageModel mainPageModel = new MainPageModel();
            mainPageModel.Bandwidth = await _context.Bandwidth.ToListAsync();
            mainPageModel.User = await _context.User.ToListAsync();

            return View(mainPageModel);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
