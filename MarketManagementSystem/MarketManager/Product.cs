using System;
using System.Collections.Generic;
using System.Text;

namespace MarketManager
{
    class Product
    {
        private static int _counter=100;
        public Product(string category)
        {
            Category = category;
            _counter++;
            Code = category.Substring(0, 2).ToUpper() + _counter;

        }
        public string Name;
        public double Price;
        public string Category;
        public int TotalCount;
        public string Code;

        public override string ToString()
        {
            return $"Mehsulun adi: {Name} - Kodu: {Code} - Qiymeti: {Price} - Kateqoriyasi: {Category} - Sayi: {TotalCount}";
        }

    }
}
