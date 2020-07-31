namespace Kampania.Requests
{
    public class CreateCampaignRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}