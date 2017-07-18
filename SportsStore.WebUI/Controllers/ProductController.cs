﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductsRepository repository;

        public int PageSize = 4;
        public ProductController(IProductsRepository productrRepository)
        {
            this.repository = productrRepository;
        }
        

        public ViewResult List(int page=1)
        {
            return View(repository.Products
                .OrderBy(p=>p.ProductID)
                .Skip((page-1)*PageSize)
                .Take(PageSize));
        }
    }
}