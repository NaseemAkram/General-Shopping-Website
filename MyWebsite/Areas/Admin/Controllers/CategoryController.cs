using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAccessLayer.Infrastructure.IRepository;
using MyWebsite.Models.ViewModel;

namespace MyWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _context;

        public CategoryController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CategoryVm catvm = new CategoryVm();
            catvm.categories = _context.Category.GetAll();
            return View(catvm);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Category cat)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Category.Add(cat);
        //        _context.Save();
        //        TempData["Success"] = "Category Created Successfully";

        //        return RedirectToAction("Index");
        //    }
        //    return View(cat);

        //}


        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVm vm = new CategoryVm();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Category = _context.Category.GetT(x => x.Id == id);
                if (vm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);

                }

            }
        }

        [HttpPost]

        public IActionResult CreateUpdate(CategoryVm vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Category.Id == 0)
                {
                    _context.Category.Add(vm.Category);
                    TempData["Success"] = "Category Added Successfully";


                }
                else
                {
                    _context.Category.Update(vm.Category);
                    TempData["Success"] = "Category Updated Successfully";


                }
                _context.Save();

                return RedirectToAction(nameof(Index));

            }
            return View(vm);

        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var findCategory = _context.Category.GetT(x => x.Id == id);

            if (findCategory == null)
            {
                return NotFound();
            }
            return View(findCategory);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var findCategory = _context.Category.GetT(x => x.Id == id);
            if (findCategory == null)
            {
                return NotFound();
            }
            _context.Category.Delete(findCategory);
            _context.Save();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
