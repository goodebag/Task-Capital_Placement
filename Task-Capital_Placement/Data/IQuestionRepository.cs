using System.Net.Mail;
using Task_Capital_Placement.Core.Entities;
using Task_Capital_Placement.Core.Models;

namespace Task_Capital_Placement.Data
{
    public interface IQuestionRepository
    {
        Task<Question> Create(QuestionDto question);
        Task Delete(string questionId);
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> GetByIdAsync(string questionId);
        Task<IEnumerable<Question>> GetByQuestionTypeAsync(QuestionType questionType);
        Task<Question> UpdateTaskAsync(Question question);
    }
}
