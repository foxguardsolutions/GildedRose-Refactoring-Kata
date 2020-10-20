using System;
using System.Collections.Generic;
using System.IO;
using static GildedRoseApp.Constants;

namespace GildedRoseApp
{
    public class Inventory
    {
        public void CreateOutput()
        {
            var items = CreateInventoryList();
            var itemAdjustments = new ItemAdjustments();

            Console.WriteLine("OMGHAI!");

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine($"-------- day {i} --------");
                Console.WriteLine("name, sellIn, quality");

                foreach (var item in items)
                {
                    System.Console.WriteLine(item);
                }

                Console.WriteLine(string.Empty);
                itemAdjustments.UpdateItemValues(items);
            }
        }

        private static IEnumerable<InventoryItem> CreateInventoryList()
        {
            return InventoryData.FromJson(File.ReadAllText(InventoryFileName));
        }
    }
}
