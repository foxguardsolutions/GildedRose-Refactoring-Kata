using GildedRoseApp;
using NUnit.Framework;
using static GildedRoseApp.Categories;

namespace GildedRoseTests
{
    [TestFixture]

    public class BackstagePassesAdjustmentTests
    {
        private InventoryItem _itemsNotExpired;
        private InventoryItem _itemsExpired;
        private InventoryItem _backstagePassTenDay;
        private InventoryItem _backstagePassFiveDay;

        [SetUp]
        public void Init()
        {
            _itemsNotExpired = new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Category = CategoryList.BackstagePasses };
            _itemsExpired = new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0, Category = CategoryList.BackstagePasses };
            _backstagePassTenDay = new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 25, Category = CategoryList.BackstagePasses };
            _backstagePassFiveDay = new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 35, Category = CategoryList.BackstagePasses };
        }

        [Test]
        [TestCase(15, 20, 14, 21)]
        public void UpdateItemValues_GivenSellInAndQualityOfBackstagePassesNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new BackStagePassesAdjustments();
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
        [TestCase(-1, 0, -2, 0)]
        public void UpdateItemValues_GivenSellInAndQualityOfBackstagePassesExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new BackStagePassesAdjustments();
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

        [Test]
        [TestCase(10, 25, 9, 27)]
        public void UpdateItemValues_GivenSellInAndQualityOfBackstagePassesTenDaysBeforeShow_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _backstagePassTenDay;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new BackStagePassesAdjustments();
            itemAdjustments.Update(_backstagePassTenDay);
            var standardAfterAdjustment = _backstagePassTenDay;

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
            var standardBeforeAdjustment = _backstagePassFiveDay;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new BackStagePassesAdjustments();
            itemAdjustments.Update(_backstagePassFiveDay);
            var standardAfterAdjustment = _backstagePassFiveDay;

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
