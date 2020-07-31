using System.Collections.Generic;
using Kampania.DTOs;

namespace Kampania.Responses
{
    public class RaportResponse
    {
        public bool Success { get; set; }
        public RaportDto Raport { get; set; }
        public List<string> Errors { get; set; }
        public RaportResponse()
        {
            Errors = new List<string>();
        }
    }
}