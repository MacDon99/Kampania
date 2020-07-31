using System.Collections.Generic;
using Kampania.DTOs;

namespace Kampania.Responses
{
    public class CampaignResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public CampaignDto Campaign { get; set; }
        public List<string> Errors { get; set; }
        public CampaignResponse()
        {
            Errors = new List<string>();
        }
    }
}