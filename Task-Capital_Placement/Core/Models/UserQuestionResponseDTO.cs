using Newtonsoft.Json;
using Task_Capital_Placement.Core.Entities;

namespace Task_Capital_Placement.Core.Models
{
    public class UserQuestionResponseDTO
    {
        [JsonProperty("questionId")]
        public string QuestionId { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
}
