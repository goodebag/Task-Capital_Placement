using Newtonsoft.Json;

namespace Task_Capital_Placement.Core.Entities
{
    /// <summary>
    /// IsActive is for a soft delete is not a good approach to hard delete in certain sensitive applications
    /// </summary>

    public class EntityBase
    {
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }=true;
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
