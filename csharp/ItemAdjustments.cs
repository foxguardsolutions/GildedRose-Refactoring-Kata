using System.Collections.Generic;
using System.Linq;
using static GildedRoseApp.Categories;
using static GildedRoseApp.CategoryCommands;

namespace GildedRoseApp
{
    public class ItemAdjustments
    {
        private IItemAdjustments _updatedItem; 
        private static CategoryCommands _categoryCommands = new CategoryCommands();
        private IDictionary<CategoryList, IItemAdjustments> _adjustmentCommand = _categoryCommands.AdjustmentCommand;

        public void UpdateItemValues(IEnumerable<InventoryItem> items)
        {
            foreach (var item in items)
            {
                var itemAdjustments = this._adjustmentCommand.Single(i => i.Key == item.Category).Value;
                this._updatedItem = itemAdjustments;
                this._updatedItem.Update(item);
            }
        }
    }
}
