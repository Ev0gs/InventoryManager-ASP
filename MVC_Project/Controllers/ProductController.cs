using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using MVC_Project.Services;

namespace MVC_Project.Controllers
{
    public class ProductController(IProductRepository products) : Controller
    {
        public IActionResult Index()
        {
            return View(products.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.GetById(id);
            if (product is null)
                return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(product);

            if (products.GetById(id) is null)
                return NotFound();

            products.Update(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = products.GetById(id);
            if (product is null)
                return NotFound();
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!products.Delete(id))
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
