using static GildedRoseApp.Constants;

namespace GildedRoseApp
{
    public class ConjuredBackStagePassesAdjustments : IItemAdjustments, IBackstagePasses
    {
        public InventoryItem Update(InventoryItem item)
        {
            var currentQuality = item.Quality;
            var currentSellIn = item.SellIn;
            item.SellIn = AdjustSellIn(currentSellIn,DoubleSellInDecrease);
            item.Quality = !IsPastAgedDate(item.SellIn) ? this.GetBackStagePassQualityFactorBasedOnSellInValue(item.SellIn, currentQuality) : MinQuality;
            return item;
        }

        public int GetBackStagePassQualityFactorBasedOnSellInValue(int sellIn, int currentQuality)
        {
            if (sellIn < 5)
            {
                return AdjustQuality(currentQuality, TripleQualityIncrease * ConjuredQualityFactor);
            }
            else if (sellIn < 10)
            {
                return AdjustQuality(currentQuality, DoubleQualityIncrease * ConjuredQualityFactor);
            }
            else
            {
                return AdjustQuality(currentQuality, NormalQualityIncrease * ConjuredQualityFactor);
            }
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