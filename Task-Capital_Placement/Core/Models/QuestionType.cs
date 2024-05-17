namespace Task_Capital_Placement.Core.Models
{
    /// <summary>
    /// While this can be achieved by create a table(Container in CosmosDb terms)
    /// with Id and Name properties,
    /// Since the values seems static and fewer, So I'm using enum for more simplicity.
    /// </summary>
    public enum QuestionType
    {
        Paragraph = 1,
        YesNo,
        Dropdown,
        MultipleChoice,
        Date,
        Number
    }
}
