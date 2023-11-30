using FinalProject.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Controllers
{
	public class CategoryController : Controller
	{
		private readonly AdventureWorksRepository advRepo;
		private readonly ILogger<CategoryController> logger;

		public CategoryController(AdventureWorksRepository advRepo, ILogger<CategoryController> logger)
		{
			this.advRepo = advRepo;
			this.logger = logger;
		}

		// GET: CategoryController
		public ActionResult Index()
		{
			var allCategories = advRepo.GetAllCategories();

			var model = allCategories.Where(x => x.CategoryName.Contains("e")).ToList();


			List<string> pranks = new()
			{
				"Mystery Mixer Switcheroo",
				"Colorful Condiment Confusion",
				"Sweet Disguised Delight",
				"Cereal Box Suprise Swap",
				"Mock Meat Masquerade",
				"Healthy Snack Sneak",
				"Faux Fish Fiesta"

			};
			ViewBag.Pranks = pranks;

			List<string> prankDescriptions = new(){
			"Replace the labels on soft drink bottles with labels from different but similar-looking drinks. For example, swapping the labels of a cola and a root beer. The taste difference will be subtle but noticeable, leading to a moment of confusion.",
			"Mix a very small amount of harmless food coloring into a condiment like mayonnaise or mustard. The unexpected color change when they use it will be a surprise but won't alter the flavor.", 
			"Prepare a dessert that looks like a savory item. For instance, a cake decorated to look like a pizza, or cupcakes that resemble mini burgers. The appearance will trick the eye, but the taste will reveal the sweet truth.", 
			"Swap the contents of cereal boxes with different kinds of cereals. Imagine reaching for cornflakes and finding fruity loops instead!", 
			"Create a 'faux' meat dish using vegetarian or vegan substitutes. For example, serving a vegetarian burger but presenting it as a regular beef burger. The key is to find a good quality substitute that is surprisingly similar in taste and texture.", 
			"Replace snacks like potato chips or cookies in a snack bowl with healthier alternatives like dried fruit or flavored bean curd. The unsuspecting snacker expecting a salty crunch might be surprised by the sweet or savory alternative.", 
			"Prepare a dish that looks like a classic seafood dish, like sushi, but use fruit or vegetable-based ingredients instead. For instance, making 'sashimi' slices from watermelon or mango."
			
			};
			ViewBag.prankDescriptions = prankDescriptions;

			return View(model);
		}

		

		// GET: CategoryController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: CategoryController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CategoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CategoryController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: CategoryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CategoryController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: CategoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
