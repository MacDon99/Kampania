using Kampania.Repositories;
using Kampania.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Kampania.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignController(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_campaignRepository.getCampaignById(id));
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_campaignRepository.getAllCampaigns());
        }
        [HttpGet("raport")]
        public IActionResult Raport()
        {
            return Ok(_campaignRepository.getCampaignsCost());
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateCampaignRequest request)
        {
            var response = _campaignRepository.createCampaign(request);
            if(response.Success)
                return Ok(response);
            return StatusCode(400, response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            var response = _campaignRepository.deleteCampaign(id);
            if(response.Success)
                return Ok(response);
            return StatusCode(400, response);
        }
        [HttpPatch("update")]
        public IActionResult Update([FromBody] UpdateCampaignRequest request)
        {
            var response = _campaignRepository.updateCampaign(request);
            if(response.Success)
                return Ok(response);

            return StatusCode(400, response);

        }
    }
}