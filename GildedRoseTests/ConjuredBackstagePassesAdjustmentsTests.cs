using GildedRoseApp;
using static GildedRoseApp.Categories;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]

    public class ConjuredBackstagePassesAdjustmentsTests
    {
        private InventoryItem _itemsNotExpired;
        private InventoryItem _itemsExpired;
        private InventoryItem _backstagePassTenDay;
        private InventoryItem _backstagePassFiveDay;

        [SetUp]
        public void Init()
        {
            _itemsNotExpired = new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 15, Quality = 40, Category = CategoryList.ConjuredBackstagePasses };
            _itemsExpired = new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = -15, Quality = 0, Category = CategoryList.ConjuredBackstagePasses };
            _backstagePassTenDay =new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 9, Quality = 38, Category = CategoryList.ConjuredBackstagePasses };
            _backstagePassFiveDay = new InventoryItem { Name = "Backstage passes to a CONJURED80ETC concert", SellIn = 4, Quality = 35, Category = CategoryList.ConjuredBackstagePasses };
        }

        [Test]
        [TestCase(15, 40, 13, 42)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredBackstagePassNonExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsNotExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ConjuredBackStagePassesAdjustments();
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
        [TestCase(-15, 0, -17, 0)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredBackstagePassExpiredItem_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _itemsExpired;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ConjuredBackStagePassesAdjustments();
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
        [TestCase(9, 38, 7, 42)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredBackstagePassesTenDaysBeforeShow_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _backstagePassTenDay;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ConjuredBackStagePassesAdjustments();
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
        [TestCase(4, 35, 2, 41)]
        public void UpdateItemValues_GivenSellInAndQualityOfConjuredBackstagePassesFiveDaysBeforeShow_ReturnUpdatedSellInAndQuality(int sellIn, int quality, int updatedSellIn, int updatedQuality)
        {
            var standardBeforeAdjustment = _backstagePassFiveDay;
            var beforeAdjustmentSellIn = standardBeforeAdjustment.SellIn;
            var beforeAdjustmentQuality = standardBeforeAdjustment.Quality;

            var itemAdjustments = new ConjuredBackStagePassesAdjustments();
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
