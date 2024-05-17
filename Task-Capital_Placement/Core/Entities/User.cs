using Newtonsoft.Json;

namespace Task_Capital_Placement.Core.Entities
{
    public class User:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email{ get; set; }
        public string PhoneNumber { get; set; }
        public string ResidentialCountry { get; set; }
        public string Country { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ProgrammeId { get; set; }
        public List<UserQuestionResponse> QuestionResponses { get; set; }
    }
    public class UserQuestionResponse:EntityBase
    {
  
        [JsonProperty("question")]
        public Question Question { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
}
