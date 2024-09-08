using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapp_Lagersystem_Intervju
{
    internal class Storage
    {
        List<IProduct> AllProducts = new List<IProduct>();

        public void AddProduct(IProduct product)
        {
            AllProducts.Add(product);
        }

        public void RemoveProduct(int product)
        {
            Mobile mobile = new Mobile("iPhone 15 – 5G", 14.76, 7.16, 0.78, 171, 2023, "Sort", 6.1, "2556x1179", "Apple A16 Bionic", "Nei", "Litium - ion", 15, "Ja", "USB - C", "60hz", 128, 004);
            TV tv = new TV();
            Washing_Machine washingmachine = new Washing_Machine();
            Grill grill = new Grill();
            Spade spade = new Spade();

            if (AllProducts[product] is Mobile)
            {
                Console.WriteLine($"Item has been removed: {((Mobile)AllProducts[product]).Name}");
            }
            else if (AllProducts[product] is TV)
            {
                Console.WriteLine($"Item has been removed: {((TV)AllProducts[product]).Name}");
            }
            else if (AllProducts[product] is Washing_Machine)
            {
                Console.WriteLine($"Item has been removed: {((Washing_Machine)AllProducts[product]).Name}");
            }
            else if (AllProducts[product] is Grill)
            {
                Console.WriteLine($"Item has been removed: {((Grill)AllProducts[product]).Name}");
            }
            else if (AllProducts[product] is Spade)
            {
                Console.WriteLine($"Item has been removed: {((Spade)AllProducts[product]).Name}");
            }
            AllProducts.RemoveAt(product);
        }

        public void ListAllProductsInStorage()
        {
            foreach (var item in AllProducts)
            {
                item.WriteOutInfo();
            }
        }
    }
}
