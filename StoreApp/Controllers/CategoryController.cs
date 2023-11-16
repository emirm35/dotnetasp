using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;
using Services;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        /*  private readonly IRepositoryManager _manager;

         public CategoryController(IRepositoryManager manager)
         {
             _manager = manager;
         }
  */


        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }


        /*   public IEnumerable<Category> Index()
          {
              return _manager.Category.FindAll(false);
          } */

        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetAllCategories(false).ToList();
            return View(model);
        }
    }
}