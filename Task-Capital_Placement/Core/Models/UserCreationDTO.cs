using System.ComponentModel.DataAnnotations;

namespace Task_Capital_Placement.Core.Models
{
    public record UserCreationDTO
    {
        [Required]
        public PersonalData PersonalData  { get; set; }
        public List<UserQuestionResponseDTO> AdditionQuestions { get; set; }
    }
}
