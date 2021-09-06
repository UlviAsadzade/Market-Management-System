using System;
using System.Collections.Generic;
using System.Text;

namespace MarketManager
{
    class MarketManager
    {
        public List<Product> Products = new List<Product>(0);
        public List<Sale> Sales = new List<Sale>(0);

        public bool CheckName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (name.Length > 1)
                {
                    if (Char.IsUpper(name[0]))
                    {
                        foreach (var chr in name)
                        {
                            if (Char.IsLetter(chr) == false)
                            {
                                return false;

                            }
                        }
                        return true;
                    }

                }
            }

            return false;
        }

        public bool FindProductByName(string name)
        {
            if(Products.Exists(x => x.Name == name))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void AddProduct(string name,double price,string category,int count)
        {
            Products.Add(new Product(category) { Name = name, Price = price, TotalCount = count });
        }

        public void EditProduct(string code, string name, double price, string category, int count)
        {
            foreach (var item in Products)
            {
                if (item.Code == code)
                {
                    item.Name = name;
                    item.Price = price;
                    item.Category = category;
                    item.TotalCount = count;
                }
            }
        }

        public void RemoveProduct(string code)
        {
            var product = Products.Find(x => x.Code == code);
            if (Products.Contains(product))
            {
                Products.Remove(product);
            }
        }

        public void ShowAllProducts()
        {
            if (Products.Count > 0)
            {
                foreach (var item in Products)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Hecbir mehsul movcud deyil");
            }
        }

        public void ShowProductsByCategory(string category)
        {
            foreach (var item in Products)
            {
                if (item.Category == category)
                {
                    Console.WriteLine(item);
                }
            }

        }

        public void ShowProductsOfPrice(double minprice, double maxprice)
        {
            foreach (var item in Products)
            {
                if (item.Price < maxprice && item.Price > minprice)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void SearchMenuItemOfName(string text)
        {
            foreach (var item in Products)
            {
                if (item.Name.Contains(text))
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void AddSale(double amount, DateTime date, List<SaleItem> saleItems)
        {
            Sales.Add(new Sale { Amount = amount, Date = date, SaleItems = saleItems });

        }

        public void EditSale(int no,string name, int count)
        {
            foreach (var sale in Sales)
            {
                if (sale.No == no)
                {
                    foreach (var saleItem in sale.SaleItems)
                    {
                        if (saleItem.Product.Name == name)
                        {
                            saleItem.Count = count;
                        }
                    }
                }
            }
        }

        public void RemoveSale(int no)
        {
            var sale = Sales.Find(x => x.No == no);
            if (Sales.Contains(sale))
            {
                Sales.Remove(sale);
            }
        }

        public void ShowSalesByDateInterval(DateTime from, DateTime to)
        {
            var sales = Sales.FindAll(x => x.Date > from && x.Date < to);

            foreach (var sale in sales)
            {
                Console.WriteLine($"Satisin nomresi: {sale.No} - Meblegi: {sale.Amount} - Tarixi: {sale.Date}");
                foreach (var prd in sale.SaleItems)
                {
                    Console.WriteLine($"Mehsullarin adi: {prd.Product.Name} - Sayi: {prd.Count}");
                }
            }
        }

        public void ShowSalesOfAmount(double minprice, double maxprice)
        {
            var sales = Sales.FindAll(x => x.Amount > minprice && x.Amount < maxprice);

            foreach (var sale in sales)
            {
                Console.WriteLine($"Satisin nomresi: {sale.No} - Meblegi: {sale.Amount} - Tarixi: {sale.Date}");
                foreach (var prd in sale.SaleItems)
                {
                    Console.WriteLine($"Mehsullarin adi: {prd.Product.Name} - Sayi: {prd.Count}");
                }
            }
        }

        public void ShowSalesByDate(DateTime date)
        {
            var sales = Sales.FindAll(x => x.Date == date);

            foreach (var sale in sales)
            {
                Console.WriteLine($"Satisin nomresi: {sale.No} - Meblegi: {sale.Amount} - Tarixi: {sale.Date}");
                foreach (var prd in sale.SaleItems)
                {
                    Console.WriteLine($"Mehsullarin adi: {prd.Product.Name} - Sayi: {prd.Count}");
                }
            }

        }

        public void ShowSalesByNo(int no)
        {
            var sales = Sales.FindAll(x => x.No == no);

            foreach (var sale in sales)
            {
                Console.WriteLine($"Satisin nomresi: {sale.No} - Meblegi: {sale.Amount} - Tarixi: {sale.Date}");
                foreach (var prd in sale.SaleItems)
                {
                    Console.WriteLine($"Mehsullarin adi: {prd.Product.Name} - Sayi: {prd.Count}");
                }
            }
        }


    }
}
