using GildedRoseApp;
using static GildedRoseApp.Categories;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]

    public class ConjuredAdjustmentsTests
    {
        private InventoryItem _itemsNotExpired;
        private InventoryItem _itemsExpired;

        [SetUp]
        public void Init()
        {
            _itemsNotExpired = new InventoryItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Category = CategoryList.Conjured };
            _itemsExpired = new InventoryItem { Name = "Conjured Mana Cake", SellIn = -8, Quality = 0, Category = CategoryList.Conjured };
        }

        [Test]
        [TestCase(3, 6, 2, 4)]
        public void UpdateItemValues_GivenSellInAndQualityOfStandardConjuredNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ConjuredAdjustments();
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
        [TestCase(-8, 0, -9, 0)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredStandardExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ConjuredAdjustments();
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
