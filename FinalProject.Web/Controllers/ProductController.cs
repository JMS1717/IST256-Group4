using FinalProject.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace FinalProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly AdventureWorksRepository advRepo;
        private readonly ILogger<ProductController> logger;

        public ProductController(AdventureWorksRepository advRepo, ILogger<ProductController> logger)
        {
            this.advRepo = advRepo;
            this.logger = logger;
        }

        // GET: Product/Index
        public ActionResult Index()
        {
            var allProducts = advRepo.GetAllProducts();
            // You might want to perform additional operations or filtering here
            return View(allProducts);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = advRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Or handle error gracefully
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // Logic to create a new product based on form data
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = advRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Or handle error gracefully
            }
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // Logic to update product based on form data
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = advRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Or handle error gracefully
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // Logic to delete product based on ID
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
