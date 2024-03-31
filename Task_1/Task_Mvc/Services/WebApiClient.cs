using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Task_Mvc.BaseEntity;
using Task_Mvc.Interface;

namespace Task_Mvc.Services
{
    public class WebApiClient : IApiClient
    {
        public HttpClient _httpClient;
       

        protected string BuildCompleteUri(string relativePath)
        {
            // Using a URI will help us to validate the URL before making an invalid call.
            ApiBaseUrl apiBaseUrl = new ApiBaseUrl();
            string returnUri = string.Concat(apiBaseUrl.baseUrl, relativePath);
            return returnUri;
        }

        public async Task<ApiResponse> DeleteAsync(string relativePath )
        {
            Uri completeUri = new Uri(this.BuildCompleteUri(relativePath));
            ApiResponse response = new ApiResponse();

            HttpResponseMessage apiResponse = await this.Client.DeleteAsync(completeUri);
            if (apiResponse.IsSuccessStatusCode)
            {
                string responseData = apiResponse.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrWhiteSpace(responseData))
                {
                    response.IsSuccessful = true;
                    response.Data = responseData;
                }
            }
            else
            {
                // TODO: Log Errors
            }

            return response;
        }

        public async Task<ApiResponse> GetAsync(string relativePath)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                Uri completeUri = new Uri(this.BuildCompleteUri(relativePath));

                HttpResponseMessage apiResponse = await this.Client.GetAsync(completeUri);
                if (apiResponse.IsSuccessStatusCode)
                {
                    string responseData = apiResponse.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrWhiteSpace(responseData))
                    {
                        response.IsSuccessful = true;
                        response.Data = responseData;
                    }
                }
                else
                {
                    string responseData = apiResponse.Content.ReadAsStringAsync().Result;
                    response.IsSuccessful = false;
                    response.Data = responseData;
                    // TODO: Log Errors
                }
            }
            catch (Exception ex)
            {
		 // No action required; exception will propagate
	    }

            return response;
        }

        public async Task<ApiResponse> PostAsync(string relativePath, object obj)
        {
            Uri completeUri = new Uri(this.BuildCompleteUri(relativePath));
            ApiResponse response = new ApiResponse();

            HttpResponseMessage apiResponse = await this.Client.PostAsJsonAsync(completeUri, obj);
            if (apiResponse.IsSuccessStatusCode)
            {
                string responseData = apiResponse.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrWhiteSpace(responseData))
                {
                    response.IsSuccessful = true;
                    response.Data = responseData;
                }
            }
            else
            {
                response.IsSuccessful = false;
                response.Data = "";
                // TODO: Log Errors
            }

            return response;
        }

        public ApiResponse PostSync(string relativePath,  object obj)
        {
            Uri completeUri = new Uri(this.BuildCompleteUri(relativePath));
            ApiResponse response = new ApiResponse();

            HttpResponseMessage apiResponse = this.Client.PostAsJsonAsync(completeUri, obj).Result;
           
            if (apiResponse.IsSuccessStatusCode)
            {
                string responseData = apiResponse.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrWhiteSpace(responseData))
                {
                    response.IsSuccessful = true;
                    response.Data = responseData;
                }
            }
            else
            {
                response.IsSuccessful = false;
                response.Data = "";
                // TODO: Log Errors
            }

            return response;
        }


        public HttpClient Client
        {
            get
            {
                if (this._httpClient == null)
                {
                    this._httpClient = new HttpClient();
                    _httpClient.Timeout = TimeSpan.FromMinutes(10);
                }

                return this._httpClient;
            }
        }

    }
}
