using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    public class ProductsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //var result = await 
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Description, Price")])
        {

        }*/

        /*[HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var productVM = await 
        }*/
    }
}
