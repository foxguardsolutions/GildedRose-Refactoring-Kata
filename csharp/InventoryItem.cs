using System;

namespace GildedRoseApp
{
    public class InventoryItem : Item
    {
        public enum CategoryList
        {
            Standard,
            AgedBrie,
            Sulfuras,
            BackstagePasses,
            Conjured,
        }

        public Enum Category { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}
