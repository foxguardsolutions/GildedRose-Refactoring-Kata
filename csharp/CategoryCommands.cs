using System.Collections.Generic;
using static GildedRoseApp.Categories;

namespace GildedRoseApp
{
    public class CategoryCommands
    {
        public IDictionary<CategoryList, IItemAdjustments> AdjustmentCommand = new Dictionary<CategoryList, IItemAdjustments>()
        {
            { CategoryList.Standard, new StandardAdjustments() },
            { CategoryList.AgedBrie, new AgedBrieAdjustments() },
            { CategoryList.BackstagePasses, new BackStagePassesAdjustments() },
            { CategoryList.Conjured, new ConjuredAdjustments() },
            { CategoryList.ConjuredAgedBrie, new ConjuredAgedBrieAdjustments() },
            { CategoryList.ConjuredBackstagePasses, new ConjuredBackStagePassesAdjustments() },
            { CategoryList.Sulfuras, new SulfurasAdjustments() },
        };
    }
}
