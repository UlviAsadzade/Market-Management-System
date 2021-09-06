using System;
using System.Collections.Generic;
using System.Text;

namespace MarketManager
{
    class SaleItem
    {
        private static int _counter=0;
        public SaleItem()
        {
            _counter++;
            No += _counter;
        }
        public int No;
        public Product Product;
        public int Count;
    }
}
