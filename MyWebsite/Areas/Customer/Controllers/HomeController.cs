using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAccessLayer.Infrastructure.IRepository;
using MyWebsite.Models;
using MyWebsite.Models.Models;
using System.Diagnostics;

namespace MyWebsite.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitofWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
            _logger = logger;
        }

        [HttpGet]

        public IActionResult Index()
        {
            IEnumerable<Product> product = _unitofWork.Product.GetAll(includeproperties: "Category");
            return View(product);
        }
        public IActionResult Details(int? id)
        {

            Cart cart = new Cart()
            {
                Product = _unitofWork.Product.GetT(x => x.Id == id, includeproperties: "Category"),
                Count = 1
            };
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details()
        {
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