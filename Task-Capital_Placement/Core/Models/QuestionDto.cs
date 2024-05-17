namespace Task_Capital_Placement.Core.Models
{
    public record QuestionDto
    {
        public string Question { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
