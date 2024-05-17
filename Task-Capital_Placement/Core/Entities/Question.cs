using Newtonsoft.Json;
using Task_Capital_Placement.Core.Models;

namespace Task_Capital_Placement.Core.Entities
{
    public class Question: EntityBase
    {
        [JsonProperty("writeUp")]
        public string WriteUp { get; set; }
        [JsonProperty("questionType")]
        public  QuestionType QuestionType { get; set; }
        
    }
}
