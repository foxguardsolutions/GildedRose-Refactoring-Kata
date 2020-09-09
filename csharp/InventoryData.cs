using System.Collections.Generic;
using Newtonsoft.Json;

namespace GildedRoseApp
{
    public partial class InventoryData
    {
        public static List<InventoryItem> FromJson(string json) =>
            JsonConvert.DeserializeObject<List<InventoryItem>>(json);
    }
}
