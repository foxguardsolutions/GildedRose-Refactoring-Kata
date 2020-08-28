using System;
using GildedRoseApp;
using NUnit.Framework;
using static GildedRoseApp.InventoryItem;

namespace GildedRoseTests
{
    [TestFixture]
    public class InventoryItemTests
    {
        [Test]
        [TestCase("+5 Dexterity Vest", 10, 20, CategoryList.Standard, "+5 Dexterity Vest", 10, 20, "Standard")]
        [TestCase("Aged Brie", 2, 0, CategoryList.AgedBrie, "Aged Brie", 2, 0, "AgedBrie")]
        [TestCase("Elixir of the Mongoose", 5, 7, CategoryList.Standard, "Elixir of the Mongoose", 5, 7, "Standard")]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, 80, CategoryList.Sulfuras, "Sulfuras, Hand of Ragnaros", 0, 80, "Sulfuras")]
        [TestCase("Sulfuras, Hand of Ragnaros", -1, 80, CategoryList.Sulfuras, "Sulfuras, Hand of Ragnaros", -1, 80, "Sulfuras")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 20, CategoryList.BackstagePasses, "Backstage passes to a TAFKAL80ETC concert", 15, 20, "BackstagePasses")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 49, CategoryList.BackstagePasses, "Backstage passes to a TAFKAL80ETC concert", 10, 49, "BackstagePasses")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 49, CategoryList.BackstagePasses, "Backstage passes to a TAFKAL80ETC concert", 5, 49, "BackstagePasses")]
        [TestCase("Conjured Mana Cake", 3, 6, CategoryList.Conjured, "Conjured Mana Cake", 3, 6, "Conjured")]

        public void InventoryItem_GivenCreationOfInventoryItem_ReturnsCorrectAssignedProperties(string name, int sellIn, int quality, Enum category,
            string expName, int expSellIn, int expQuality, string expCategory)
        {
            var inventoryItem = new InventoryItem{ Name = name, SellIn = sellIn, Quality = quality, Category = category};
            Assert.Multiple(() =>
            {
                Assert.That(inventoryItem.Name, Is.EqualTo(expName));
                Assert.That(inventoryItem.SellIn, Is.EqualTo(expSellIn));
                Assert.That(inventoryItem.Quality, Is.EqualTo(expQuality));
                Assert.That(inventoryItem.Category.ToString(), Is.EqualTo(expCategory));
            });
        }

        [Test]
        [TestCase("+5 Dexterity Vest", 10, 20, CategoryList.Standard, "+5 Dexterity Vest, 10, 20")]
        [TestCase("Aged Brie", 2, 0, CategoryList.AgedBrie, "Aged Brie, 2, 0")]
        [TestCase("Elixir of the Mongoose", 5, 7, CategoryList.Standard, "Elixir of the Mongoose, 5, 7")]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, 80, CategoryList.Sulfuras, "Sulfuras, Hand of Ragnaros, 0, 80")]
        [TestCase("Sulfuras, Hand of Ragnaros", -1, 80, CategoryList.Sulfuras, "Sulfuras, Hand of Ragnaros, -1, 80")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 20, CategoryList.BackstagePasses, "Backstage passes to a TAFKAL80ETC concert, 15, 20")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 49, CategoryList.BackstagePasses, "Backstage passes to a TAFKAL80ETC concert, 10, 49")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 49, CategoryList.BackstagePasses, "Backstage passes to a TAFKAL80ETC concert, 5, 49")]
        [TestCase("Conjured Mana Cake", 3, 6, CategoryList.Conjured, "Conjured Mana Cake, 3, 6")]

        public void InventoryItem_GivenCreationOfInventoryItem_ReturnsCorrectToStringOverrideAssignment(string name, int sellIn, int quality, Enum category, string expToStringOverride)
        {
            var inventoryItem = new InventoryItem { Name = name, SellIn = sellIn, Quality = quality, Category = category };
            Assert.That(inventoryItem.ToString(), Is.EqualTo(expToStringOverride));
        }

        [Test]
        [TestCase("AgedBrie", InventoryItem.CategoryList.AgedBrie)]
        [TestCase("BackstagePasses", InventoryItem.CategoryList.BackstagePasses)]
        [TestCase("Conjured", InventoryItem.CategoryList.Conjured)]
        [TestCase("Standard", InventoryItem.CategoryList.Standard)]
        [TestCase("Sulfuras", InventoryItem.CategoryList.Sulfuras)]
        public void CategoryList_GivenEnumProperties_ReturnsCorrectEnum(string category, Enum categoryEnum)
        {
            var inventoryItem = new InventoryItem {Category = categoryEnum};
            Assert.That(inventoryItem.Category.ToString(), Is.EqualTo(category));
        }
    }
}
