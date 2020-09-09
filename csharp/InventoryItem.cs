using static GildedRoseApp.Categories;

namespace GildedRoseApp
{
    public class InventoryItem : Item
    {
        public CategoryList Category { get; set; }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}
