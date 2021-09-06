using System;
using System.Collections.Generic;
using System.Text;

namespace MarketManager
{
    class Sale
    {
        private static int _counter = 0;
        public Sale()
        {
            _counter++;
            No += _counter;
        }
        public int No;
        public double Amount;
        public List<SaleItem> SaleItems=new List<SaleItem>(0);
        public DateTime Date;

        public void AddSaleItems(Product product, int count)
        {
            SaleItems.Add(new SaleItem { Product = product, Count = count });
        }

        
    }
}
