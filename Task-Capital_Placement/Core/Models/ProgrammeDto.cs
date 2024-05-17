using Newtonsoft.Json;

namespace Task_Capital_Placement.Core.Models
{
    public class ProgrammeDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
