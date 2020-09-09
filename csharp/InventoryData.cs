using System.Collections.Generic;
using Newtonsoft.Json;
using static GildedRoseApp.InventoryItem;

namespace GildedRoseApp
{
    public partial class InventoryData
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("SellIn")]
        public long SellIn { get; set; }

        [JsonProperty("Quality")]
        public long Quality { get; set; }

        [JsonProperty("Category")] 
        public CategoryList Category { get; set; }
    }

    public partial class InventoryData
    {
        public static List<InventoryItem> FromJson(string json) =>
            JsonConvert.DeserializeObject<List<InventoryItem>>(json);
    }
}
