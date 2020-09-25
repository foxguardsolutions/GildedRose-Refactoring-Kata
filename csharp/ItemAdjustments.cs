using System.Collections.Generic;
using static GildedRoseApp.Categories;

namespace GildedRoseApp
{
    public class ItemAdjustments
    {
        private IItemAdjustments _updatedItem;

        public void UpdateItemValues(IEnumerable<InventoryItem> items)
        {
            foreach (var item in items)
            {
                switch (item.Category)
                {
                    case CategoryList.AgedBrie:
                        this._updatedItem = new AgedBrieAdjustments(item);
                        this._updatedItem.Update();
                        break;
                    case CategoryList.BackstagePasses:
                        this._updatedItem = new BackStagePassesAdjustments(item);
                        this._updatedItem.Update();
                        break;
                    case CategoryList.Sulfuras:
                        this._updatedItem = new SulfurasAdjustments(item);
                        this._updatedItem.Update();
                        break;
                    case CategoryList.Conjured:
                        this._updatedItem = new ConjuredAdjustments(item);
                        this._updatedItem.Update();
                        break;
                    case CategoryList.ConjuredAgedBrie:
                        this._updatedItem = new ConjuredAgedBrieAdjustments(item);
                        this._updatedItem.Update();
                        break;
                    case CategoryList.ConjuredBackstagePasses:
                        this._updatedItem = new ConjuredBackStagePassesAdjustments(item);
                        this._updatedItem.Update();
                        break;
                    default:
                        this._updatedItem = new StandardAdjustments(item);
                        this._updatedItem.Update();
                        break;
                }
            }
        }
    }
}
