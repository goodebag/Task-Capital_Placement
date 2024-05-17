namespace Task_Capital_Placement.Core.Models
{
    public class CosmosDbSettings
    {
        public string Url { get; set; }
        public string PrimaryKey { get; set; }
        public string PrimaryConnectionString { get; set; }
        public string MongoConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
