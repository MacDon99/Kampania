namespace Kampania.Requests
{
    public class UpdateCampaignRequest
    {
        public string Id { get; set; }
        public string newName { get; set; }
        public string newDescription { get; set; }
        public decimal newCost { get; set; }
    }
}