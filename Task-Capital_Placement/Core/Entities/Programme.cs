using Newtonsoft.Json;

namespace Task_Capital_Placement.Core.Entities
{
    public class Programme: EntityBase
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
