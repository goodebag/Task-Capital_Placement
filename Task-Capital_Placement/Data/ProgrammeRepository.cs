using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Task_Capital_Placement.Core.Entities;
using Task_Capital_Placement.Core.Models;

namespace Task_Capital_Placement.Data
{
    public class ProgrammeRepository: IProgrammeRepository

    {

        private readonly CosmosClient _cosmosClient;
        private readonly Container _programmeContainer;
        public ProgrammeRepository(CosmosClient cosmosClient, CosmosDbSettings cosmosDbSettings)
        {
            string containerName = $"{typeof(Programme).Name}s";
            _cosmosClient = cosmosClient;
            _programmeContainer = _cosmosClient.GetContainer(cosmosDbSettings.DatabaseName, containerName);
        }

        public async Task<Programme> Create(ProgrammeDto programmeDto)
        {
            Programme programme= new Programme();
            programme.Id = Guid.NewGuid().ToString();
            programme.Title = programmeDto.Title;
            programme.Description = programmeDto.Description;
            var response = await _programmeContainer.CreateItemAsync(programme);
            return response.Resource;
        }

        public async Task Delete(string id)
        {
            await _programmeContainer.DeleteItemAsync<Programme>(id, new PartitionKey(id));
        }

        public async Task<IEnumerable<Programme>> GetAllAsync()
        {
            var query = _programmeContainer.GetItemLinqQueryable<Programme>()
              .Where(t => t.IsActive == true)
              .ToFeedIterator();

            var questions = new List<Programme>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                questions.AddRange(response);
            }

            return questions;
        }

        public async Task<Programme> GetByIdAsync(string id)
        {
            var query = _programmeContainer.GetItemLinqQueryable<Programme>()
             .Where(t => t.IsActive == true && t.Id == id)
             .Take(1)
             .ToQueryDefinition();

            var sqlQuery = query.QueryText; // Retrieve the SQL query

            var response = await _programmeContainer.GetItemQueryIterator<Programme>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<Programme> UpdateAsync(Programme question)
        {
            var response = await _programmeContainer.ReplaceItemAsync(question, question.Id);
            return response.Resource;
        }
    }
}
