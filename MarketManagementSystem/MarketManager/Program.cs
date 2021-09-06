using System;
using System.Collections.Generic;

namespace MarketManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MarketManager market = new MarketManager();

            string ans;
            do
            {
                Console.WriteLine("\n==============================================\n");

                Console.WriteLine("1 - Mehsullar uzerinde emeliyyat aparmaq");
                Console.WriteLine("2 - Satislar uzerinde emeliyyat aparmaq");
                Console.WriteLine("0 - sistemden cixis");

                Console.WriteLine("\nIcra etmek istediyiniz emeliyyati secin:");
                ans = Console.ReadLine();

                Console.WriteLine("\n==============================================\n");

                switch (ans)
                {
                    case "1":

                        Console.WriteLine("\n==============================================\n");

                        Console.WriteLine("1.1 - Yeni mehsul elave et");
                        Console.WriteLine("1.2 - Mehsul uzerinde duzelis et");
                        Console.WriteLine("1.3 - Mehsulu sil");
                        Console.WriteLine("1.4 - Butun mehsullari goster");
                        Console.WriteLine("1.5 - Categoriyasina gore mehsullari goster");
                        Console.WriteLine("1.6 - Qiymet araligina gore mehsullari goster");
                        Console.WriteLine("1.7 - Mehsullar arasinda ada gore axtaris etmek");
                        Console.WriteLine("0.0 - Evvelki menuya qayit");


                        Console.WriteLine("\nIcra etmek istediyiniz emeliyyati secin:");
                        ans = Console.ReadLine();

                        Console.WriteLine("\n==============================================\n");

                        switch (ans)
                        {
                            case "1.1":
                                AddProduct(market);
                                break;
                            case "1.2":
                                EditProduct(market);
                                break;
                            case "1.3":
                                RemoveProduct(market);
                                break;
                            case "1.4":
                                market.ShowAllProducts();
                                break;
                            case "1.5":
                                ShowAProductsByCategory(market);
                                break;
                            case "1.6":
                                ShowProductByPrice(market);
                                break;
                            case "1.7":
                                SearchMenuItemOfName(market);
                                break;
                            case "0.0":
                                
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n==============================================\n");

                        Console.WriteLine("2.1 - Yeni satis elave etmek ");
                        Console.WriteLine("2.2 - Satisdaki hansisa mehsulun geri qaytarilmasi( satisdan cixarilmasi)");
                        Console.WriteLine("2.3 - Satisin silinmesi ");
                        Console.WriteLine("2.4 - Butun satislarin ekrana cixarilmasi");
                        Console.WriteLine("2.5 - Verilen tarix araligina gore satislarin gosterilmesi");
                        Console.WriteLine("2.6 - Verilen mebleg araligina gore satislarin gosterilmesi");
                        Console.WriteLine("2.7 - Verilmis bir tarixde olan satislarin gosterilmesi");
                        Console.WriteLine("2.8 - Verilmis nomreye esasen hemin nomreli satisin melumatlarinin gosterilmesi");
                        Console.WriteLine("0.0 - Evvelki menuya qayit");

                        Console.WriteLine("\nIcra etmek istediyiniz emeliyyati secin:");
                        ans = Console.ReadLine();

                        Console.WriteLine("\n==============================================\n");

                        switch (ans)
                        {
                            case "2.1":
                                AddSale(market);
                                break;
                            case "2.2":
                                EditSale(market);
                                break;
                            case "2.3":
                                RemoveSale(market);
                                break;
                            case "2.4":
                                ShowAllSales(market);
                                break;
                            case "2.5":
                                ShowSalesByDateInterval(market);
                                break;
                            case "2.6":
                                ShowSalesOfAmount(market);
                                break;
                            case "2.7":
                                ShowSalesByDate(market);
                                break;
                            case "2.8":
                                ShowSalesByNo(market);
                                break;
                            case "0.0":
                                
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

            } while (ans != "0");
        }

        static void AddProduct(MarketManager market)
        {
            startaddname:
            string name;
            bool check = true;
            do
            {
                if (check)
                {
                    Console.WriteLine("Elave etmek istediyiniz mehsulun adini daxil edin:");
                }
                else
                {
                    Console.WriteLine("Mehsul adinda reqem ola bilmez, ilk herfi boyuk olmali ve minimum 2 herfli olmalidir, yeniden daxil edin");
                }
                name = Console.ReadLine();
                check = false;

            } while (!market.CheckName(name));

            if (market.FindProductByName(name))
            {
                Console.WriteLine("\n==============================================\n");
                Console.WriteLine("Bu adda basqa mehsul movcuddur");

                goto startaddname;
            }

            double price;
            string pricestr;
            check = true;
            do
            {

                if (check)
                    Console.WriteLine("Mehsulun qiymetini daxil edin:");
                else
                    Console.WriteLine("Qiymet yazarken herf olmamalidir ve qiymet 0-dan asagi olmamalidir, yeniden daxil edin");

                pricestr = Console.ReadLine();
                check = false;

            } while (!double.TryParse(pricestr, out price) || price < 0);

            string category;
            check = true;
            do
            {
                if (check)
                {
                    Console.WriteLine("Elave etmek istediyiniz mehsulun kateqoriyasini daxil edin:");
                }
                else
                {
                    Console.WriteLine("Mehsulun Kategoriyasinda reqem ola bilmez, ilk herfi boyuk olmali ve minimum 2 herfli olmalidir, yeniden daxil edin");
                }
                category = Console.ReadLine();
                check = false;

            } while (!market.CheckName(category));

            int count;
            string countstr;
            check = true;
            do
            {

                if (check)
                    Console.WriteLine("Mehsulun sayini daxil edin:");
                else
                    Console.WriteLine("Sayi yazarken herf olmamalidir ve qiymet 0-dan asagi olmamalidir, yeniden daxil edin");

                countstr = Console.ReadLine();
                check = false;

            } while (!int.TryParse(countstr, out count) || count < 0);

            market.AddProduct(name, price, category, count);
        }

        static void EditProduct(MarketManager market)
        {
            if (market.Products.Count > 0)
            {
                string code;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Deyismek istediyiniz mehsulun kodunu daxil edin :");
                    else
                        Console.WriteLine("Bu koda uygun mehsul movcud deyil, yeniden daxil edin");

                    code = Console.ReadLine();
                    check = false;

                    if(market.Products.Exists(x=> x.Code == code))
                    {
                        check = true;
                    }

                } while (check == false);

                starteditname:
                string name;
                check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Deyismek istediyiniz mehsulun adini daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Mehsul adinda reqem ola bilmez, ilk herfi boyuk olmali ve minimum 2 herfli olmalidir, yeniden daxil edin");
                    }
                    name = Console.ReadLine();
                    check = false;

                } while (!market.CheckName(name));

                if (market.FindProductByName(name))
                {
                    Console.WriteLine("\n==============================================\n");
                    Console.WriteLine("Bu adda basqa mehsul movcuddur");
                    Console.WriteLine("\n==============================================\n");

                    goto starteditname;
                }

                double price;
                string pricestr;
                check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Mehsulun qiymetini daxil edin:");
                    else
                        Console.WriteLine("Qiymet yazarken herf olmamalidir ve qiymet 0-dan asagi olmamalidir, yeniden daxil edin");

                    pricestr = Console.ReadLine();
                    check = false;

                } while (!double.TryParse(pricestr, out price) || price < 0);

                string category;
                check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Mehsulun kateqoriyasini daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Mehsulun Kategoriyasinda reqem ola bilmez, ilk herfi boyuk olmali ve minimum 2 herfli olmalidir, yeniden daxil edin");
                    }
                    category = Console.ReadLine();
                    check = false;

                } while (!market.CheckName(category));

                int count;
                string countstr;
                check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Mehsulun sayini daxil edin:");
                    else
                        Console.WriteLine("Sayi yazarken herf olmamalidir ve sayi 0-dan asagi olmamalidir, yeniden daxil edin");

                    countstr = Console.ReadLine();
                    check = false;

                } while (!int.TryParse(countstr, out count) || count < 0);

                market.EditProduct(code, name, price, category, count);
            }
            else
            {
                Console.WriteLine("Hecbir mehsul movcud deyil");
            }
        }

        static void RemoveProduct(MarketManager market)
        {
            if (market.Products.Count > 0)
            {
                string code;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Silmek istediyiniz mehsulun kodunu daxil edin :");
                    else
                        Console.WriteLine("Bu koda uygun mehsul movcud deyil, yeniden daxil edin");

                    code = Console.ReadLine();
                    check = false;

                    if (market.Products.Exists(x => x.Code == code))
                    {
                        check = true;
                    }

                } while (check == false);

                market.RemoveProduct(code);
            }
            else
            {
                Console.WriteLine("Hecbir mehsul movcud deyil");
            }
        }

        static void ShowAProductsByCategory(MarketManager market)
        {
            if (market.Products.Count > 0)
            {
                foreach (var item in market.Products)
                {
                    Console.WriteLine($"Movcud olan butun kateqoriyalar bunlardir: {item.Category}");
                }

                string category;
                bool check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Gormek istediyiniz mehsullarin kateqoriyasini daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Mehsulun Kategoriyasinda reqem ola bilmez, ilk herfi boyuk olmali ve minimum 2 herfli olmalidir, yeniden daxil edin");
                    }
                    category = Console.ReadLine();
                    check = false;

                } while (!market.CheckName(category));

                Console.WriteLine("\nSecdiyiniz kateqoriyaya uygun Menu Itemler asagidaki kimidir\n");
                market.ShowProductsByCategory(category);
            }
            else
            {
                Console.WriteLine("Hecbir mehsul movcud deyil");
            }
        }

        static void ShowProductByPrice(MarketManager market)
        {
            if (market.Products.Count > 0)
            {
                double minprice;
                string minpricestr;
                bool check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Minimum qiymeti daxil edin:");
                    else
                        Console.WriteLine("Qiymet yazarken herf olmamalidir ve qiymet 0-dan asagi olmamalidir, yeniden daxil edin");

                    minpricestr = Console.ReadLine();
                    check = false;

                } while (!double.TryParse(minpricestr, out minprice) || minprice < 0);


                double maxprice;
                string maxpricestr;
                check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Maximum qiymeti daxil edin:");
                    else
                        Console.WriteLine("Qiymet yazarken herf olmamalidir ve maksimum qiymet minimumdan asagi olmamalidir, yeniden daxil edin");

                    maxpricestr = Console.ReadLine();
                    check = false;

                } while (!double.TryParse(maxpricestr, out maxprice) || maxprice < minprice);

                Console.WriteLine("\nQiymet araligina uygun Menu Itemler asagidaki kimidir\n");
                market.ShowProductsOfPrice(minprice, maxprice);
            }
            else
            {
                Console.WriteLine("Hecbir mehsul movcud deyil");
            }
        }

        static void SearchMenuItemOfName(MarketManager market)
        {
            if (market.Products.Count > 0)
            {
                string text;
                bool check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Axtaris etmek istediyiniz sozu daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Soz daxil ederken bosluq olmamalidir, yeniden daxil edin");
                    }
                    text = Console.ReadLine();
                    check = false;

                } while (string.IsNullOrWhiteSpace(text));

                Console.WriteLine("\nAxtardiginiz soze uygun Menu Itemler asagidaki kimidir\n");
                market.SearchMenuItemOfName(text);
            }
            else
            {
                Console.WriteLine("Hecbir mehsul movcud deyil");
            }
        }

        static void AddSale(MarketManager market)
        {
            List<SaleItem> saleItems = new List<SaleItem>(0);

        startaddsale:
            if (market.Products.Count > 0)
            {
                Console.WriteLine("\nMarketdeki butun mehsullar asagidaki kimidir\n");
                market.ShowAllProducts();

                Product prd;
                string code;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Secmek istediyiniz mehsulun kodunu daxil edin :");
                    else
                        Console.WriteLine("Bu koda uygun mehsul movcud deyil, yeniden daxil edin");

                    code = Console.ReadLine();
                    check = false;

                    prd = market.Products.Find(x => x.Code == code);

                    if (prd!=null)
                    {
                        check = true;
                    }

                } while (check == false);

                int count;
                string countstr;
                check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Mehsuldan ne qeder isteyirsiz?");
                    else
                        Console.WriteLine("Mehsulun depodaki miqdarindan cox sece bilmersiz, yeniden daxil edin");

                    countstr = Console.ReadLine();
                    check = false;

                } while (!int.TryParse(countstr, out count) || count > prd.TotalCount);

                SaleItem saleItem = new SaleItem()
                {
                    Product = prd,
                    Count = count
                };

                saleItems.Add(saleItem);
                saleItem.Product.TotalCount -= count;


                string answer;

                Console.WriteLine("Satisa davam etmek isteyirsiz? y/n");
                answer = Console.ReadLine();
                if (answer == "y")
                {
                    goto startaddsale;
                }

                DateTime date;
                string datestr;
                check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Satisin tarixini daxil edin");
                    else
                        Console.WriteLine("Tarixi duzgun daxil edin");

                    datestr = Console.ReadLine();
                    check = false;

                } while (!DateTime.TryParse(datestr, out date));

                
                double amount = 0;
                foreach (var item in saleItems)
                {
                    amount += item.Product.Price * item.Count;
                }

                market.AddSale(amount, date, saleItems);
            }
            else
            {
                Console.WriteLine("Hecbir mehsul movcud deyil");
            }
        }

        static void EditSale(MarketManager market)
        {

            if (market.Sales.Count > 0)
            {
            starteditsaleno:
                int no;
                string nostr;
                bool check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Deyismek istediyiniz satisin nomresini daxil edin:");
                    else
                        Console.WriteLine("Nomre yazarken herf olmamalidir ve 0-dan asagi olmamalidir, yeniden daxil edin");

                    nostr = Console.ReadLine();
                    check = false;

                } while (!int.TryParse(nostr, out no) || no < 0);

                if(!market.Sales.Exists(x=> x.No == no))
                {
                    Console.WriteLine("Daxil etdiyiniz nomreye uygun satis yoxdur");
                    goto starteditsaleno;

                }

            starteditsalename:
                string name;
                check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Deyismek istediyiniz mehsulun adini daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Mehsul adinda reqem ola bilmez, ilk herfi boyuk olmali ve minimum 2 herfli olmalidir, yeniden daxil edin");
                    }
                    name = Console.ReadLine();
                    check = false;

                } while (!market.CheckName(name));

                SaleItem saleItem = new SaleItem();

                foreach (var sale in market.Sales)
                {
                    foreach (var item in sale.SaleItems)
                    {
                        if (item.Product.Name == name)
                        {
                            saleItem.Count = item.Count;
                        }
                        else
                        {
                            Console.WriteLine("Daxil etdiyiniz ada uygun mehsul movcud deyil");
                            goto starteditsalename;
                        }
                    }

                }

                int count;
                string countstr;
                check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Satistaki mehsulun sayi ne qeder olsun?");
                    else
                        Console.WriteLine("Mehsulun sayi evvelki sayidan cox ola bilmez, yeniden daxil edin");

                    countstr = Console.ReadLine();
                    check = false;

                } while (!int.TryParse(countstr, out count) || count > saleItem.Count);


                market.EditSale(no, name, count);

            }
            else
            {
                Console.WriteLine("Hecbir satis movcud deyil");
            }
        }

        static void RemoveSale(MarketManager market)
        {
            if (market.Sales.Count > 0)
            {
            startremovesaleno:
                int no;
                string nostr;
                bool check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Silmek istediyiniz satisin nomresini daxil edin:");
                    else
                        Console.WriteLine("Nomre yazarken herf olmamalidir ve 0-dan asagi olmamalidir, yeniden daxil edin");

                    nostr = Console.ReadLine();
                    check = false;

                } while (!int.TryParse(nostr, out no) || no < 0);

                if (!market.Sales.Exists(x => x.No == no))
                {
                    Console.WriteLine("Daxil etdiyiniz nomreye uygun satis yoxdur");
                    goto startremovesaleno;
                }

                market.RemoveSale(no);

            }
            else
            {
                Console.WriteLine("Hecbir satis movcud deyil");
            }
        }

        static void ShowAllSales(MarketManager market)
        {
            if (market.Sales.Count > 0)
            {
                foreach (var sale in market.Sales)
                {
                    Console.WriteLine($"Satisin nomresi: {sale.No} - Meblegi: {sale.Amount} - Tarixi: {sale.Date}");
                    foreach (var prd in sale.SaleItems)
                    {
                        Console.WriteLine($"Mehsullarin adi: {prd.Product.Name} - Sayi: {prd.Count}");
                    }
                }
            }
            else
            {
                Console.WriteLine( "Hecbir satis movcud deyil" );
            }
        }

        static void ShowSalesByDateInterval(MarketManager market)
        {
            if (market.Sales.Count > 0)
            {
                DateTime from;
                string fromstr;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Hansi tarixden?");
                    else
                        Console.WriteLine("Tarixi duzgun daxil edin");

                    fromstr = Console.ReadLine();
                    check = false;

                } while (!DateTime.TryParse(fromstr, out from));

                DateTime to;
                string tostr;
                check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Hansi tarixe?");
                    else
                        Console.WriteLine("Tarixi duzgun daxil edin");

                    tostr = Console.ReadLine();
                    check = false;

                } while (!DateTime.TryParse(tostr, out to));

                Console.WriteLine("\nTarix araligina uygun satislar asagidaki kimidir\n");
                market.ShowSalesByDateInterval(from, to);

            }
            else
            {
                Console.WriteLine("Hecbir satis movcud deyil");
            }
        }

        static void ShowSalesOfAmount(MarketManager market)
        {
            if (market.Sales.Count > 0)
            {
                double minprice;
                string minpricestr;
                bool check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Minimum meblegi daxil edin:");
                    else
                        Console.WriteLine("Meblegi yazarken herf olmamalidir ve qiymet 0-dan asagi olmamalidir, yeniden daxil edin");

                    minpricestr = Console.ReadLine();
                    check = false;

                } while (!double.TryParse(minpricestr, out minprice) || minprice < 0);


                double maxprice;
                string maxpricestr;
                check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Maximum meblegi daxil edin:");
                    else
                        Console.WriteLine("Meblegi yazarken herf olmamalidir ve maksimum mebleg minimumdan asagi olmamalidir, yeniden daxil edin");

                    maxpricestr = Console.ReadLine();
                    check = false;

                } while (!double.TryParse(maxpricestr, out maxprice) || maxprice < minprice);

                Console.WriteLine("\nQiymet araligina uygun satislar asagidaki kimidir\n");
                market.ShowSalesOfAmount(minprice, maxprice);

            }
            else
            {
                Console.WriteLine("Hecbir satis movcud deyil");
            }
        }

        static void ShowSalesByDate(MarketManager market)
        {
            if (market.Sales.Count > 0)
            {
                ShowSalesByDate:
                DateTime date;
                string datestr;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Hansi tarixdeki satislari gormek isteyirsiz?");
                    else
                        Console.WriteLine("Tarixi duzgun daxil edin");

                    datestr = Console.ReadLine();
                    check = false;

                } while (!DateTime.TryParse(datestr, out date));

                if (!market.Sales.Exists(x => x.Date == date))
                {
                    Console.WriteLine("Daxil etdiyiniz gune uygun satis yoxdur");
                    goto ShowSalesByDate;
                }

                Console.WriteLine("\nTarixe  uygun satislar asagidaki kimidir\n");
                market.ShowSalesByDate(date);

            }
            else
            {
                Console.WriteLine("Hecbir satis movcud deyil");
            }
        }

        static void ShowSalesByNo(MarketManager market)
        {
            if (market.Sales.Count > 0)
            {
            showsalesbyno:
                int no;
                string nostr;
                bool check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Gormek istediyiniz satisin nomresini daxil edin:");
                    else
                        Console.WriteLine("Nomre yazarken herf olmamalidir ve 0-dan asagi olmamalidir, yeniden daxil edin");

                    nostr = Console.ReadLine();
                    check = false;

                } while (!int.TryParse(nostr, out no) || no < 0);

                if (!market.Sales.Exists(x => x.No == no))
                {
                    Console.WriteLine("Daxil etdiyiniz nomreye uygun satis yoxdur");
                    goto showsalesbyno;
                }

                Console.WriteLine("\nTarixe  uygun satislar asagidaki kimidir\n");
                market.ShowSalesByNo(no);

            }
            else
            {
                Console.WriteLine("Hecbir satis movcud deyil");
            }
        }


    }
}
