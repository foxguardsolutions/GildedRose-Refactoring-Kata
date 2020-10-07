using GildedRoseApp;
using static GildedRoseApp.Categories;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]

    public class StandardAdjustmentsTests
    {
        private InventoryItem _itemsNotExpired;
        private InventoryItem _itemsExpired;

        [SetUp]
        public void Init()
        {
            _itemsNotExpired = new InventoryItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Category = CategoryList.Standard};
            _itemsExpired = new InventoryItem { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 8, Category = CategoryList.Standard };
        }

        [Test]
        [TestCase(10, 20, 9, 19)]
        public void UpdateItemValues_GivenSellInAndQualityOfStandardNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new StandardAdjustments();
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
        [TestCase(-1, 8, -2, 6)]
        public void UpdateItemValues_GivenSellInAndQualityOfStandardExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new StandardAdjustments();
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
