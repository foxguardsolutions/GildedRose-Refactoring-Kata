using System.Collections.Generic;
using static GildedRoseApp.InventoryItem;

namespace GildedRoseApp
{
    public class ItemAdjustments
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private const int MinAgedDate = 0;
        private const int NormalQualityIncrease = 1;
        private const int DoubleQualityIncrease = 2;
        private const int TripleQualityIncrease = 3;
        private const int NormalQualityDecrease = -1;
        private const int DoubleQualityDecrease = -2;

        public void UpdateItemValues(IEnumerable<InventoryItem> items)
        {
            foreach (var item in items)
            {
                if (!item.Category.Equals(CategoryList.Sulfuras)) { item.SellIn -= 1; }

                switch (item.Category)
                {
                    case CategoryList.AgedBrie:
                        UpdateAgedBrie(item);
                        break;
                    case CategoryList.BackstagePasses:
                        UpdateBackStagePass(item);
                        break;
                    case CategoryList.Sulfuras:
                        UpdateSulfuras(item);
                        break;
                    case CategoryList.Conjured:
                        UpdateConjured(item);
                        break;
                    default:
                        UpdateStandard(item);
                        break;
                }
            }
        }

        private static int GetQualityIncrease(int quality, int adjustment)
        {
            return (quality + adjustment >= MaxQuality) ? MaxQuality : quality += adjustment;
        }

        private static int GetQualityDecrease(int quality, int adjustment)
        {
            return (quality + adjustment <= MinQuality) ? MinQuality : quality += adjustment;
        }

        private static bool IsPastAgedDate(int sellIn) => sellIn < MinAgedDate ? true : false;

        private static void UpdateAgedBrie(InventoryItem item)
        {
            var currentQuality = item.Quality;
            item.Quality = IsPastAgedDate(item.SellIn) ? GetQualityIncrease(currentQuality, DoubleQualityIncrease) : GetQualityIncrease(currentQuality, NormalQualityIncrease);
        }

        private static void UpdateBackStagePass(InventoryItem item)
        {
            item.Quality = !IsPastAgedDate(item.SellIn) ? GetBackStagePassQuality(item) : MinQuality;
        }

        private static int GetBackStagePassQuality(InventoryItem item)
        {
            var currentQuality = item.Quality;

            if (item.SellIn < 5)
            {
                return GetQualityIncrease(currentQuality, TripleQualityIncrease);
            }
            else if (item.SellIn < 10)
            {
                return GetQualityIncrease(currentQuality, DoubleQualityIncrease);
            }
            else
            {
                return GetQualityIncrease(currentQuality, NormalQualityIncrease);
            }
        }

        private static void UpdateSulfuras(InventoryItem item) { return; }

        private static void UpdateStandard(InventoryItem item)
        {
            var currentQuality = item.Quality;
            item.Quality = GetQualityDecrease(currentQuality, item.SellIn < 0 ? DoubleQualityDecrease : NormalQualityDecrease);
        }

        private static void UpdateConjured(InventoryItem item)
        {
            var currentQuality = item.Quality;
            item.Quality = GetQualityDecrease(currentQuality, item.SellIn < 0 ? DoubleQualityDecrease : NormalQualityDecrease);
        }
    }
}
