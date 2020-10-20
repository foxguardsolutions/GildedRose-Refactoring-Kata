using static GildedRoseApp.Constants;

namespace GildedRoseApp
{
    public class StandardAdjustments : IItemAdjustments
    {
        public InventoryItem Update(InventoryItem item)
        {
            var currentQuality = item.Quality;
            var currentSellIn = item.SellIn;
            item.SellIn = AdjustSellIn(currentSellIn,NormalSellInDecrease);
            item.Quality = AdjustQuality(currentQuality, item.SellIn < 0 ? DoubleQualityDecrease : NormalQualityDecrease);
            return item;
        }

        private static int AdjustQuality(int quality, int adjustment)
        {
            return (quality + adjustment <= MinQuality) ? MinQuality : quality + adjustment;
        }

        private static int AdjustSellIn(int sellIn, int adjustment)
        {
            return sellIn + adjustment;
        }
    }
}
