using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.Sales;
using StoreOfBuild.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace StoreOfBuild.Web.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly SaleFactory _saleFactory;
        private readonly IRepository<Product> _repository;

        public SaleController(SaleFactory saleFactory, IRepository<Product> repository)
        {
            _saleFactory = saleFactory;
            _repository = repository;
        }

        public IActionResult Create()
        {
            var products = _repository.All();

            //if (products.Any())
            //{
                var productViewModel = products.Select(prod => new ProductViewModel { Id = prod.Id, Name = prod.Name });
                return View(new SaleViewModel { Products = productViewModel });
            //}

            //return View();
        }
        [HttpPost]
        public IActionResult Create(SaleViewModel viewModel)
        {
            _saleFactory.Create(viewModel.ClientName, viewModel.ProductId, viewModel.Quantity);
            
            return Ok();
        }
    }
}