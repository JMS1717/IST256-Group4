using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
