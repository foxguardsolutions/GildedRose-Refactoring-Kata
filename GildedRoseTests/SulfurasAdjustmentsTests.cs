using GildedRoseApp;
using static GildedRoseApp.Categories;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    
    class SulfurasAdjustmentsTests
    {
        private InventoryItem _itemsNotExpired;
        private InventoryItem _itemsExpired;

        [SetUp]
        public void Init()
        {
            _itemsNotExpired = new InventoryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Category = CategoryList.Sulfuras};
            _itemsExpired = new InventoryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80, Category = CategoryList.Sulfuras };
        }

        [Test]
        [TestCase(0, 80, 0, 80)]
        public void UpdateItemValues_GivenSellInAndQualityOfSulfurasNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new SulfurasAdjustments();
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
        [TestCase(-1, 80, -1, 80)]
        public void UpdateItemValues_GivenSellInAndQualityOfSulfurasExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new SulfurasAdjustments();
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
