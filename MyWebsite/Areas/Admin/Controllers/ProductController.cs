using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAccessLayer.Infrastructure.IRepository;
using MyWebsite.Models.ViewModel;

namespace MyWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IUnitOfWork _context;

        private readonly IWebHostEnvironment _environment;

        public ProductController(IUnitOfWork context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }

        //Api call

        #region ApiCall

        public IActionResult AllProducts()
        {
            var allproducts = _context.Product.GetAll(includeproperties: "Category");
            return Json(new { Data = allproducts });
        }

        #endregion


        public IActionResult Index()
        {
            //ProductVM provm = new ProductVM();
            //provm.Products = _context.Product.GetAll();
            return View();
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
            ProductVM vm = new ProductVM()
            {
                product = new(),
                Categories = _context.Category.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.product = _context.Product.GetT(x => x.Id == id);
                if (vm.product == null)
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

        public IActionResult CreateUpdate(ProductVM vm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string fileName = String.Empty;
                if (file != null)
                {
                    string uploadDir = Path.Combine(_environment.WebRootPath, "ProductImage");
                    fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    vm.product.ImageUrl = @"\ProductImage\" + fileName;
                }
                if (vm.product.Id == 0)
                {
                    _context.Product.Add(vm.product);

                }





                _context.Save();

                return RedirectToAction("Index");
            }
            return View("Index");

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

