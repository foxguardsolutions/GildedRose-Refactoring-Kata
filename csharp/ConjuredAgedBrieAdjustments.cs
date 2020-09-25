using static GildedRoseApp.Constants;

namespace GildedRoseApp
{
    public class ConjuredAgedBrieAdjustments : IItemAdjustments
    {
        public InventoryItem Update(InventoryItem item)
        {
            var currentQuality = item.Quality;
            var currentSellIn = item.SellIn;
            item.SellIn = AdjustSellIn(currentSellIn,NormalSellInDecrease);
            item.Quality = IsPastAgedDate(item.SellIn) ? AdjustQuality(currentQuality, DoubleQualityIncrease * ConjuredQualityFactor) :
                                                                     AdjustQuality(currentQuality, NormalQualityIncrease * ConjuredQualityFactor);
            return item;
        }

        private static int AdjustQuality(int quality, int adjustment)
        {
            return (quality + adjustment >= MaxQuality) ? MaxQuality : quality + adjustment;
        }
        private static int AdjustSellIn(int sellIn, int adjustment)
        {
            return sellIn + adjustment;
        }

        private static bool IsPastAgedDate(int sellIn) => sellIn < MinAgedDate ? true : false;
    }
}