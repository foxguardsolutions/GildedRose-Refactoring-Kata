using NUnit.Framework;
using System.IO;
using System;
using GildedRoseApp;

namespace GildedRoseTests
{
    [TestFixture]
    public class InventoryTests
    {
        private string[] _results;

        [SetUp]
        public void Init()
        {
            var inventory = new Inventory();
            var sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetIn(new StringReader("a\n"));
            inventory.CreateOutput();
            _results = sw.ToString().Replace("\r", "").Split('\n');
        }

        [Test]
        public void CreateOutput_GivenInventoryList_VerifyCreationOfThirtyDaysOfUpdates()
        {
            Assert.Contains("-------- day 30 --------", _results);
        }

        [Test]
        public void CreateOutput_GivenInventoryList_VerifyCreationOfDay20Results()
        {
            Assert.Multiple(() =>
            {
                Assert.Contains("-------- day 20 --------", _results);
                Assert.Contains("name, sellIn, quality", _results);
                Assert.Contains("+5 Dexterity Vest, -10, 0", _results);
                Assert.Contains("Aged Brie, -18, 38", _results);
                Assert.Contains("Elixir of the Mongoose, -15, 0", _results);
                Assert.Contains("Sulfuras, Hand of Ragnaros, 0, 80", _results);
                Assert.Contains("Sulfuras, Hand of Ragnaros, -1, 80", _results);
                Assert.Contains("Backstage passes to a TAFKAL80ETC concert, -5, 0", _results);
                Assert.Contains("Backstage passes to a TAFKAL80ETC concert, -10, 0", _results);
                Assert.Contains("Backstage passes to a TAFKAL80ETC concert, -15, 0", _results);
                Assert.Contains("Conjured Mana Cake, -17, 0", _results);
            });
        }
    }
}
