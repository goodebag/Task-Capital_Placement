using Microsoft.AspNetCore.Mvc;
using Task_Capital_Placement.Core.Entities;
using Task_Capital_Placement.Core.Models;
using Task_Capital_Placement.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_Capital_Placement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        [HttpGet("GetQuestionTypes")]
        public async Task<IActionResult> GetQuestionTypes()
        {

            var response = new
            {
                questionTypes = Enum.GetNames(typeof(QuestionType))
            };
            return Ok(response);
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        {
            var questions = await _questionRepository.GetAllAsync();
            return Ok(questions);
        }
        [HttpGet("GetByQuestionType")]
        public async Task<ActionResult<IEnumerable<Question>>> GetByQuestionType(QuestionType questionType)
        {
            var questions = await _questionRepository.GetByQuestionTypeAsync(questionType);
            return Ok(questions);
        }

        [HttpGet("GetById/{questionId}")]
        public async Task<ActionResult<Question>> GetById(string questionId)
        {
            var question = await _questionRepository.GetByIdAsync(questionId);
            if (question == null)
            {
                return NotFound();
            }
            return question;
        }
        [HttpPost]
        public async Task<ActionResult<Question>> Create(QuestionDto question)
        {
          

            var createdTask = await _questionRepository.Create(question);
            return CreatedAtAction(nameof(GetById), new { questionId = createdTask.Id }, createdTask);
        }
        [HttpPut("{questionId}")]
        public async Task<ActionResult<Question>> Update(string questionId, Question question)
        {
            var existingTask = await _questionRepository.GetByIdAsync(questionId);
            if (existingTask == null)
            {
                return NotFound();
            }

            question.Id = existingTask.Id; // Preserve the original ID

            var updatedTask = await _questionRepository.UpdateTaskAsync(question);
            return Ok(updatedTask);
        }
    }
}
