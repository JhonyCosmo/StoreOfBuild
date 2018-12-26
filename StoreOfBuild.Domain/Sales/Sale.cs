using StoreOfBuild.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreOfBuild.Domain.Sales
{
    public class Sale: Entity
    {
        public string ClientName {get; private set;}
        public DateTime  CreatedOn { get; private set; }
        public Decimal Total { get; private set; }
        public SaleItem Item { get; private set; }

        private Sale() { }

        public Sale(string clienteName,Product product,int quantity)
        {
            DomainException.When(string.IsNullOrEmpty(clienteName), "Cliente name is required");            
            Item = new SaleItem(product,quantity);
            CreatedOn = DateTime.Now;
            ClientName = clienteName;
        }
    }
}
