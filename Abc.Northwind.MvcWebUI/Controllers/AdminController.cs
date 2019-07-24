using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Busines.Abstract;
using Abc.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }
    }
}