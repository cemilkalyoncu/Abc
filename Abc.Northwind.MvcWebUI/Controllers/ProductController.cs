﻿using Abc.Northwind.Busines.Abstract;
using Abc.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //formdan veya urlden modelbinding kullanımı parametre "page=1"
        //querystring gibi düşünebilirsin.
        public ActionResult Index(int page=1,int category=0)
        {
            //her bir sayfada 10 ürün olsun simdilik sabit değer.
            int pageSize = 5;
            var products = _productService.GetByCategory(category);
            ProductListViewModel model = new ProductListViewModel
            {
                //ilk 10 ürünü atla(skip) sonraki 10 ürünü al(take)
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page
            };
            return View(model);
        }
        //public string Session()
        //{
        //    HttpContext.Session.SetString("city","Ankara");
        //    HttpContext.Session.SetInt32("age", 32);

        //    HttpContext.Session.GetString("city");
        //    HttpContext.Session.GetInt32("age");

        //}
    }
}
