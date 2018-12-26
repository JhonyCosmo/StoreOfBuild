using StoreOfBuild.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreOfBuild.Domain.Sales
{
    public class SaleFactory
    {
        IRepository<Sale> _saleRepository;
        IRepository<Product> _productRepository;

        public SaleFactory(IRepository<Sale> saleRepository, IRepository<Product> productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }
        public void Create(string clienteName,int productId, int quantity)
        {
            var product = _productRepository.GetById(productId);
            product.RemoveFromStock(quantity);

            var sale = new Sale(clienteName, product, quantity);
            _saleRepository.Save(sale);

        }

    }
}
