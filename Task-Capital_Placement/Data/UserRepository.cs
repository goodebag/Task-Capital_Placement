using Microsoft.Azure.Cosmos;
using Task_Capital_Placement.Core.Entities;
using Task_Capital_Placement.Core.Models;
using User = Task_Capital_Placement.Core.Entities.User;

namespace Task_Capital_Placement.Data
{
    public class UserRepository:IUserRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IQuestionRepository _questionRepository;
        private readonly Container _UserContainer;
        public UserRepository(CosmosClient cosmosClient, CosmosDbSettings cosmosDbSettings, IQuestionRepository questionRepository)
        {
            string containerName = $"{typeof(User).Name}s";
            _cosmosClient = cosmosClient;
            _UserContainer = _cosmosClient.GetContainer(cosmosDbSettings.DatabaseName, containerName);
            _questionRepository = questionRepository;
        }
        public async Task<User> CreateUser(UserCreationDTO data)
        {
            var questions = await _questionRepository.GetAllAsync();
            User user = new User();
            user.Id = Guid.NewGuid().ToString();
            user.FirstName = data.PersonalData.FirstName;
            user.LastName = data.PersonalData.LastName;
            user.Email = data.PersonalData.Email;
            user.DateOfBirth = data.PersonalData.DateOfBirth;
            user.Gender = data.PersonalData.Gender;
            user.PhoneNumber = data.PersonalData.PhoneNumber;
            user.Country = data.PersonalData.Country;
            user.ResidentialCountry= data.PersonalData.ResidentialCountry;
            user.IDNumber = data.PersonalData.IDNumber;
            user.ProgrammeId= data.PersonalData.ProgrammeId;
            user.QuestionResponses = new List<UserQuestionResponse>();
            foreach (var reply in data.AdditionQuestions)
            {
                var questionResponse = new UserQuestionResponse();
                questionResponse.Question= new Question();
                questionResponse.Question = questions.FirstOrDefault(x => x.Id == reply.QuestionId);
                questionResponse.Answer = reply.Answer;
                questionResponse.Id = Guid.NewGuid().ToString();
                user.QuestionResponses.Add( questionResponse);
            }
            var response = await _UserContainer.CreateItemAsync(user);
            return response.Resource;
        }

    }
}
