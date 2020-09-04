using System;
using System.Collections.Generic;
using static GildedRoseApp.InventoryItem;

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
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");

                foreach (var item in items)
                {
                    System.Console.WriteLine(item);
                }

                Console.WriteLine("");
                itemAdjustments.UpdateItemValues(items);
            }
        }

        private static IEnumerable<InventoryItem> CreateInventoryList()
        {
            return new List<InventoryItem>
            {
                new InventoryItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Category = CategoryList.Standard },
                new InventoryItem { Name = "Aged Brie", SellIn = 2, Quality = 0, Category = CategoryList.AgedBrie },
                new InventoryItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Category = CategoryList.Standard },
                new InventoryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Category = CategoryList.Sulfuras },
                new InventoryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, Category = CategoryList.Sulfuras },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Category = CategoryList.Conjured },
                new InventoryItem { Name = "ConjuredAged Brie", SellIn = 10, Quality = 12, Category = CategoryList.ConjuredAgedBrie },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 15, Quality = 40, Category = CategoryList.ConjuredBackstagePasses },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 10, Quality = 40, Category = CategoryList.ConjuredBackstagePasses },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 5, Quality = 40, Category = CategoryList.ConjuredBackstagePasses },
            };
        }
    }
}
