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
        private const int ConjuredQualityFactor = 2;

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
                    case CategoryList.ConjuredAgedBrie:
                        UpdateConjuredAgedBrie(item);
                        break;
                    case CategoryList.ConjuredBackstagePasses:
                        UpdateConjuredBackStagePass(item);
                        break;
                    default:
                        UpdateStandard(item);
                        break;
                }
            }
        }

        private static int GetCurrentQuality(InventoryItem item)
        {
            return item.Quality;
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
            item.Quality = IsPastAgedDate(item.SellIn) ? GetQualityIncrease(GetCurrentQuality(item), DoubleQualityIncrease) : GetQualityIncrease(GetCurrentQuality(item), NormalQualityIncrease);
        }

        private static void UpdateBackStagePass(InventoryItem item)
        {
            item.Quality = !IsPastAgedDate(item.SellIn) ? GetBackStagePassQuality(item) : MinQuality;
        }

        private static int GetBackStagePassQuality(InventoryItem item)
        {
            if (item.SellIn < 5)
            {
                return GetQualityIncrease(GetCurrentQuality(item), TripleQualityIncrease);
            }
            else if (item.SellIn < 10)
            {
                return GetQualityIncrease(GetCurrentQuality(item), DoubleQualityIncrease);
            }
            else
            {
                return GetQualityIncrease(GetCurrentQuality(item), NormalQualityIncrease);
            }
        }

        private static void UpdateSulfuras(InventoryItem item) { return; }

        private static void UpdateStandard(InventoryItem item)
        {
            item.Quality = GetQualityDecrease(GetCurrentQuality(item), item.SellIn < 0 ? DoubleQualityDecrease : NormalQualityDecrease);
        }

        private static void UpdateConjured(InventoryItem item)
        {
            item.Quality = GetQualityDecrease(GetCurrentQuality(item), item.SellIn < 0 ? DoubleQualityDecrease * ConjuredQualityFactor : NormalQualityDecrease * ConjuredQualityFactor);
        }

        private static void UpdateConjuredAgedBrie(InventoryItem item)
        {
            item.Quality = IsPastAgedDate(item.SellIn) ? GetQualityIncrease(GetCurrentQuality(item), DoubleQualityIncrease * ConjuredQualityFactor) :
                                                         GetQualityIncrease(GetCurrentQuality(item), NormalQualityIncrease * ConjuredQualityFactor);
        }

        private static void UpdateConjuredBackStagePass(InventoryItem item)
        {
            item.SellIn -= 1;
            item.Quality = !IsPastAgedDate(item.SellIn) ? GetConjuredBackStagePassQuality(item) : MinQuality;
        }

        private static int GetConjuredBackStagePassQuality(InventoryItem item)
        {
            if (item.SellIn < 5)
            {
                return GetQualityIncrease(GetCurrentQuality(item), TripleQualityIncrease * ConjuredQualityFactor);
            }
            else if (item.SellIn < 10)
            {
                return GetQualityIncrease(GetCurrentQuality(item), DoubleQualityIncrease * ConjuredQualityFactor);
            }
            else
            {
                return GetQualityIncrease(GetCurrentQuality(item), NormalQualityIncrease * ConjuredQualityFactor);
            }
        }
    }
}
