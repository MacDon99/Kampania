using System.Collections.Generic;
using Kampania.DTOs;
using Kampania.Requests;
using Kampania.Responses;

namespace Kampania.Repositories
{
    public interface ICampaignRepository
    {
         CampaignResponse getCampaignById(string id);
         CampaignsResponse getAllCampaigns();
         RaportResponse getCampaignsCost();
         CampaignResponse deleteCampaign(string id);
         CampaignResponse createCampaign(CreateCampaignRequest request);
         CampaignResponse updateCampaign(UpdateCampaignRequest request);

    }
}