using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Threading.Tasks;
using Task_Capital_Placement.Core.Entities;
using Task_Capital_Placement.Core.Models;

namespace Task_Capital_Placement.Data
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _questionContainer;
        public QuestionRepository(CosmosClient cosmosClient,CosmosDbSettings cosmosDbSettings)
        {
            string containerName =$"{typeof(Question).Name}s" ;
            _cosmosClient = cosmosClient;
            _questionContainer = _cosmosClient.GetContainer(cosmosDbSettings.DatabaseName, containerName);
        }

        public async Task<Question> Create(QuestionDto questionDto )
        {
            Question question = new Question();
            question.Id = Guid.NewGuid().ToString();
            question.WriteUp = questionDto.Question;
            question.QuestionType = questionDto.QuestionType;
            var response = await _questionContainer.CreateItemAsync(question);
            return response.Resource;
        }

        public async Task Delete(string questionId)
        {
            await _questionContainer.DeleteItemAsync<Question>(questionId, new PartitionKey(questionId));
        }
       
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            var query = _questionContainer.GetItemLinqQueryable<Question>()
              .Where(t => t.IsActive == true)
              .ToFeedIterator();

            var questions = new List<Question>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                questions.AddRange(response);
            }

            return questions;
        }

        public async Task<Question> GetByIdAsync(string questionId)
        {
            var query = _questionContainer.GetItemLinqQueryable<Question>()
             .Where(t => t.IsActive == true && t.Id == questionId)
             .Take(1)
             .ToQueryDefinition();

            var sqlQuery = query.QueryText; // Retrieve the SQL query

            var response = await _questionContainer.GetItemQueryIterator<Question>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }
        public async Task<IEnumerable<Question>> GetByQuestionTypeAsync(QuestionType questionType)
        {
            var query = _questionContainer.GetItemLinqQueryable<Question>()
              .Where(t => t.IsActive == true && t.QuestionType== questionType)
              .ToFeedIterator();

            var questions = new List<Question>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                questions.AddRange(response);
            }

            return questions;
        }
        public async Task<Question> UpdateTaskAsync(Question question)
        {
            var response = await _questionContainer.ReplaceItemAsync(question, question.Id);
            return response.Resource;
        }
    }
}
