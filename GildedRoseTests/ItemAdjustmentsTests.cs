using System.Collections.Generic;
using GildedRoseApp;
using static GildedRoseApp.Categories;
using NUnit.Framework;
using System.Linq;

namespace GildedRoseTests
{
    [TestFixture]
    
    public class ItemAdjustmentsTests
    {
        private IEnumerable<InventoryItem> _itemsNotExpired;
        private IEnumerable<InventoryItem> _itemsExpired;
        private IEnumerable<InventoryItem> _backstagePassTenDay;
        private IEnumerable<InventoryItem> _backstagePassFiveDay;

        [SetUp]
        public void Init()
        {
            _itemsNotExpired = new List<InventoryItem> {
                new InventoryItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Category = CategoryList.Standard },
                new InventoryItem { Name = "Aged Brie", SellIn = 2, Quality = 0, Category = CategoryList.AgedBrie },
                new InventoryItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Category = CategoryList.Standard },
                new InventoryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Category = CategoryList.Sulfuras },
                new InventoryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, Category = CategoryList.Sulfuras },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Category = CategoryList.Conjured },
                new InventoryItem { Name = "Conjured Aged Brie", SellIn = 10, Quality = 12, Category = CategoryList.ConjuredAgedBrie },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 15, Quality = 40, Category = CategoryList.ConjuredBackstagePasses },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 10, Quality = 40, Category = CategoryList.ConjuredBackstagePasses },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 5, Quality = 40, Category = CategoryList.ConjuredBackstagePasses },
            };

            _itemsExpired = new List<InventoryItem> {
                new InventoryItem { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 8, Category = CategoryList.Standard },
                new InventoryItem { Name = "Aged Brie", SellIn = -9, Quality = 20, Category = CategoryList.AgedBrie },
                new InventoryItem { Name = "Elixir of the Mongoose", SellIn = -6, Quality = 0, Category = CategoryList.Standard },
                new InventoryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, Category = CategoryList.Sulfuras },
                new InventoryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, Category = CategoryList.Sulfuras },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -10, Quality = 0, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -5, Quality = 0, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Conjured Mana Cake", SellIn = -8, Quality = 0, Category = CategoryList.Conjured },
                new InventoryItem { Name = "Conjured Aged Brie", SellIn = 0, Quality = 32, Category = CategoryList.ConjuredAgedBrie },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = -15, Quality = 0, Category = CategoryList.ConjuredBackstagePasses },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = -10, Quality = 0, Category = CategoryList.ConjuredBackstagePasses },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = -5, Quality = 0, Category = CategoryList.ConjuredBackstagePasses },
            };

            _backstagePassTenDay = new List<InventoryItem> {
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 25, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 9, Quality = 38, Category = CategoryList.ConjuredBackstagePasses },
            };

            _backstagePassFiveDay = new List<InventoryItem> {
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 35, Category = CategoryList.BackstagePasses },
                new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 4, Quality = 35, Category = CategoryList.ConjuredBackstagePasses },
            };
        }

        [Test]
        [TestCase(10, 20, 9, 19)]
        public void UpdateItemValues_GivenSellInAndQualityOfStandardNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired.Single(item => item.Name == "+5 Dexterity Vest" && item.Category.Equals(CategoryList.Standard));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsNotExpired);
            var standardAfterAdjustment = _itemsNotExpired.Single(item => item.Name == "+5 Dexterity Vest" && item.Category.Equals(CategoryList.Standard));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(2, 0, 1, 1)]
        public void UpdateItemValues_GivenSellInAndQualityOfAgedBrieNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired.Single(item => item.Name == "Aged Brie" && item.Category.Equals(CategoryList.AgedBrie));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsNotExpired);
            var standardAfterAdjustment = _itemsNotExpired.Single(item => item.Name == "Aged Brie" && item.Category.Equals(CategoryList.AgedBrie));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(0, 80, 0, 80)]
        public void UpdateItemValues_GivenSellInAndQualityOfSulfurasNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired.First(item => item.Name == "Sulfuras, Hand of Ragnaros" && item.Category.Equals(CategoryList.Sulfuras));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsNotExpired);
            var standardAfterAdjustment = _itemsNotExpired.First(item => item.Name == "Sulfuras, Hand of Ragnaros" && item.Category.Equals(CategoryList.Sulfuras));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(15, 20, 14, 21)]
        public void UpdateItemValues_GivenSellInAndQualityOfBackstagePassesNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Category.Equals(CategoryList.BackstagePasses));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsNotExpired);
            var standardAfterAdjustment = _itemsNotExpired.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Category.Equals(CategoryList.BackstagePasses));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(-1, 8, -2, 6)]
        public void UpdateItemValues_GivenSellInAndQualityOfStandardExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired.Single(item => item.Name == "+5 Dexterity Vest" && item.Category.Equals(CategoryList.Standard));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsExpired);
            var standardAfterAdjustment = _itemsExpired.Single(item => item.Name == "+5 Dexterity Vest" && item.Category.Equals(CategoryList.Standard));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(-9, 20, -10, 22)]
        public void UpdateItemValues_GivenSellInAndQualityOfAgedBrieExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired.Single(item => item.Name == "Aged Brie" && item.Category.Equals(CategoryList.AgedBrie));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsExpired);
            var standardAfterAdjustment = _itemsExpired.Single(item => item.Name == "Aged Brie" && item.Category.Equals(CategoryList.AgedBrie));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(-1, 80, -1, 80)]
        public void UpdateItemValues_GivenSellInAndQualityOfSulfurasExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired.First(item => item.Name == "Sulfuras, Hand of Ragnaros" && item.Category.Equals(CategoryList.Sulfuras));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsExpired);
            var standardAfterAdjustment = _itemsExpired.First(item => item.Name == "Sulfuras, Hand of Ragnaros" && item.Category.Equals(CategoryList.Sulfuras));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(-1, 0, -2, 0)]
        public void UpdateItemValues_GivenSellInAndQualityOfBackstagePassesExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Category.Equals(CategoryList.BackstagePasses));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsExpired);
            var standardAfterAdjustment = _itemsExpired.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Category.Equals(CategoryList.BackstagePasses));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(10, 25, 9, 27)]
        public void UpdateItemValues_GivenSellInAndQualityOfBackstagePassesTenDaysBeforeShow_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _backstagePassTenDay.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Category.Equals(CategoryList.BackstagePasses));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_backstagePassTenDay);
            var standardAfterAdjustment = _backstagePassTenDay.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Category.Equals(CategoryList.BackstagePasses));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(5, 35, 4, 38)]
        public void UpdateItemValues_GivenSellInAndQualityOfBackstagePassesFiveDaysBeforeShow_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _backstagePassFiveDay.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Category.Equals(CategoryList.BackstagePasses));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_backstagePassFiveDay);
            var standardAfterAdjustment = _backstagePassFiveDay.First(item => item.Name == "Backstage passes to a TAFKAL80ETC concert" && item.Category.Equals(CategoryList.BackstagePasses));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(3, 6, 2, 4)]
        public void UpdateItemValues_GivenSellInAndQualityOfStandardConjuredNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired.Single(item => item.Name == "Conjured Mana Cake" && item.Category.Equals(CategoryList.Conjured));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsNotExpired);
            var standardAfterAdjustment = _itemsNotExpired.Single(item => item.Name == "Conjured Mana Cake" && item.Category.Equals(CategoryList.Conjured));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(-8, 0, -9, 0)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredStandardExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired.Single(item => item.Name == "Conjured Mana Cake" && item.Category.Equals(CategoryList.Conjured));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsExpired);
            var standardAfterAdjustment = _itemsExpired.Single(item => item.Name == "Conjured Mana Cake" && item.Category.Equals(CategoryList.Conjured));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(10, 12, 9, 14)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredAgedBrieNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired.Single(item => item.Name == "Conjured Aged Brie" && item.Category.Equals(CategoryList.ConjuredAgedBrie));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsNotExpired);
            var standardAfterAdjustment = _itemsNotExpired.Single(item => item.Name == "Conjured Aged Brie" && item.Category.Equals(CategoryList.ConjuredAgedBrie));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(0, 32, -1, 36)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredAgedBrieExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired.Single(item => item.Name == "Conjured Aged Brie" && item.Category.Equals(CategoryList.ConjuredAgedBrie));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsExpired);
            var standardAfterAdjustment = _itemsExpired.Single(item => item.Name == "Conjured Aged Brie" && item.Category.Equals(CategoryList.ConjuredAgedBrie));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(15, 40, 13, 42)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredBackstagePassNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired.First(item => item.Name == "Backstage passes to a CONJURED80ETC concert" && item.Category.Equals(CategoryList.ConjuredBackstagePasses));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsNotExpired);
            var standardAfterAdjustment = _itemsNotExpired.First(item => item.Name == "Backstage passes to a CONJURED80ETC concert" && item.Category.Equals(CategoryList.ConjuredBackstagePasses));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(-15, 0, -17, 0)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredBackstagePassExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired.First(item => item.Name == "Backstage passes to a CONJURED80ETC concert" && item.Category.Equals(CategoryList.ConjuredBackstagePasses));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_itemsExpired);
            var standardAfterAdjustment = _itemsExpired.First(item => item.Name == "Backstage passes to a CONJURED80ETC concert" && item.Category.Equals(CategoryList.ConjuredBackstagePasses));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(9, 38, 7, 42)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredBackstagePassesTenDaysBeforeShow_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _backstagePassTenDay.Single(item => item.Name == "Backstage passes to a CONJURED80ETC concert" && item.Category.Equals(CategoryList.ConjuredBackstagePasses));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_backstagePassTenDay);
            var standardAfterAdjustment = _backstagePassTenDay.Single(item => item.Name == "Backstage passes to a CONJURED80ETC concert" && item.Category.Equals(CategoryList.ConjuredBackstagePasses));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }

        [Test]
        [TestCase(4, 35, 2, 41)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredBackstagePassesFiveDaysBeforeShow_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _backstagePassFiveDay.Single(item => item.Name == "Backstage passes to a CONJURED80ETC concert" && item.Category.Equals(CategoryList.ConjuredBackstagePasses));
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ItemAdjustments();
            itemAdjustments.UpdateItemValues(_backstagePassFiveDay);
            var standardAfterAdjustment = _backstagePassFiveDay.Single(item => item.Name == "Backstage passes to a CONJURED80ETC concert" && item.Category.Equals(CategoryList.ConjuredBackstagePasses));

            Assert.Multiple(() =>
            {
                Assert.That(beforeAdjustmentSellIn, Is.EqualTo(sellIn));
                Assert.That(standardAfterAdjustment.SellIn, Is.EqualTo(updatedSellIn));
                Assert.That(beforeAdjustmentQuality, Is.EqualTo(quality));
                Assert.That(standardAfterAdjustment.Quality, Is.EqualTo(updatedQuality));
            });
        }
    }
}
