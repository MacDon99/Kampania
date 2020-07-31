using System.Collections.Generic;
using Kampania.DTOs;
using Kampania.Models;
using System.Data;
using System.Data.SqlClient;

using Kampania.Responses;
using Dapper;
using System;
using System.Linq;
using Kampania.Requests;

namespace Kampania.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly string _connectionString;
        public CampaignRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CampaignResponse createCampaign(CreateCampaignRequest request)
        {
            var campaignToPass = new CampaignDto()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Cost = request.Cost
                    };
            var response = new CampaignResponse();
            if(request.Cost >= 0)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Query($"INSERT INTO Campaigns (Name, Description, Cost) VALUES ('{request.Name}', '{request.Description}', {request.Cost});");
                    }
                    response.Success = true;
                    response.Message = "You have successfully created new Campaign!";
                    response.Campaign = campaignToPass;
                    return response;
                }
                catch(Exception ex)
                {
                    response.Success = false;
                    response.Campaign = campaignToPass;
                    response.Errors.Add(ex.Message);
                    return response;
                }
            }
            response.Success = false;
            response.Campaign = campaignToPass;
            response.Errors.Add("Cost cannot be less than 0");
            return response;
        }

        public CampaignResponse deleteCampaign(string id)
        {
            var response = new CampaignResponse();
            if(isCorrectId(id))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Query($"DELETE FROM Campaigns WHERE Id = {id};");
                    }
                    response.Success = true;
                    response.Message = $"You have successfully deleted campaign with id = {id}";
                    return response;
                }
                catch
                {
                    response.Success = false;
                    response.Errors.Add("Wrong Campaign Id");
                    return response;
                }
            }

            response.Success = false;
            response.Errors.Add("Wrong Campaign Id");
            return response;
        }

        public CampaignsResponse getAllCampaigns()
        {
            var response = new CampaignsResponse();
            IEnumerable<CampaignDto> campaigns = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
                  {
                      campaigns = conn.Query<CampaignDto>($"SELECT * from Campaigns");
                  }
            response.Campaigns = campaigns;
            return response;
        }

        public CampaignResponse getCampaignById(string id)
        {
            var response = new CampaignResponse();
            var campaigns = getAllCampaigns();
            if(isCorrectId(id))
            {
                var campaignToPass = campaigns.Campaigns.FirstOrDefault(c => c.Id == Convert.ToInt32(id));
                if(campaignToPass != null)
                {
                    response.Success = true;
                    response.Message = "You have successfully get the following campaign";
                    response.Campaign = new CampaignDto()
                    {
                        Name = campaignToPass.Name,
                        Description = campaignToPass.Description,
                        Cost = campaignToPass.Cost
                    };
                    return response;
                }
                response.Success = false;
                response.Message = "Failed to get a campaign due to the following errors";
                response.Errors.Add("Cannot find campaign with that Id");
                return response;
            }
            response.Success = false;
            response.Message = "Failed to get a campaign due to the following errors.";
            response.Errors.Add("Please enter a correct id");
            return response;
        }

        public RaportResponse getCampaignsCost()
        {
            var response = new RaportResponse();
            var campaigns = getAllCampaigns();
            decimal totalCost = 0;
            campaigns.Campaigns.ToList().ForEach(c => totalCost += c.Cost);
            response.Success = true;
            response.Raport = new RaportDto()
            {
                Cost = totalCost,
                Quantity = campaigns.Campaigns.Count()
            };
            return response;
        }

        public CampaignResponse updateCampaign(UpdateCampaignRequest request)
        {
            var response = new CampaignResponse();
             var campaigns = getCampaignsWithIds();
             if(isCorrectId(request.Id))
             {

                var campaign = campaigns.FirstOrDefault(c => c.Id == Convert.ToInt32(request.Id));
                if(campaign != null)
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                        {
                            conn.Query($"UPDATE Campaigns SET Name = '{request.newName}', Cost= {request.newCost}, Description = '{request.newDescription}' WHERE Id = {request.Id};");
                        }
                    response.Success = true;
                    response.Message = $"You have successfully updated campaign with id = {request.Id} with the following data";
                    response.Campaign = new CampaignDto()
                    {
                        Name = request.newName,
                        Description = request.newDescription,
                        Cost = request.newCost
                    };
                    return response;
                }
             }
             response.Success = false;
             response.Message = "Cannot update campaign due to the following error";
             response.Errors.Add("Wrong id");
             return response;

        }

        private List<Campaign> getCampaignsWithIds()
        {
            IEnumerable<Campaign> campaigns = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
                  {
                      campaigns = conn.Query<Campaign>($"SELECT * from Campaigns");
                  }
            return campaigns.ToList();
        }

        private bool isCorrectId(string id)
        {
            try
            {
                Convert.ToInt32(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}