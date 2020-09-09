using System;
using System.Runtime.Serialization;

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
            ConjuredAgedBrie,
            ConjuredBackstagePasses,
        }

        public CategoryList Category { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}
