using Microsoft.AspNetCore.Mvc;
using Renderino.Models;
using Repositories;
using System.Diagnostics;

namespace Renderino.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUsersService usersReository;

		public HomeController(
			ILogger<HomeController> logger,
			IUsersService usersReository)
		{
			_logger = logger;
			this.usersReository = usersReository;
		}

		public IActionResult Index()
		{
			var users = usersReository.GetUsers("");
			return View();
		}

		public IActionResult Privacy()
		{

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}