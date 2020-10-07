using GildedRoseApp;
using static GildedRoseApp.Categories;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]

    public class ConjuredAgedBrieAdjustmentsTests
    {
        private InventoryItem _itemsNotExpired;
        private InventoryItem _itemsExpired;

        [SetUp]
        public void Init()
        {
            _itemsNotExpired = new InventoryItem { Name = "Conjured Aged Brie", SellIn = 10, Quality = 12, Category = CategoryList.ConjuredAgedBrie };
            _itemsExpired = new InventoryItem { Name = "Conjured Aged Brie", SellIn = 0, Quality = 32, Category = CategoryList.ConjuredAgedBrie };
        }

        [Test]
        [TestCase(10, 12, 9, 14)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredAgedBrieNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ConjuredAgedBrieAdjustments();
            itemAdjustments.Update(_itemsNotExpired);
            var standardAfterAdjustment = _itemsNotExpired;

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
            var standardBeforeAdjustment = _itemsExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ConjuredAgedBrieAdjustments();
            itemAdjustments.Update(_itemsExpired);
            var standardAfterAdjustment = _itemsExpired;

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
