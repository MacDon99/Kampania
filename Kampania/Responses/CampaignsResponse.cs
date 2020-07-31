using System.Collections.Generic;
using Kampania.DTOs;

namespace Kampania.Responses
{
    public class CampaignsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<CampaignDto> Campaigns { get; set; }
        public List<string> Errors { get; set; }
        public CampaignsResponse()
        {
            Errors = new List<string>();
        }
    }
}