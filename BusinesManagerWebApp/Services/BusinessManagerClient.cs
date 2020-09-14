using BusinesManagerWebApp.Models;
using BusinesManagerWebApp.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services
{
    public class BusinessManagerClient : IBusinessManagerClient
    {
        private readonly HttpClient _client;
        private readonly string _apiUrl;
        private readonly BusinessManagerClientOptions _config;

        public BusinessManagerClient(IOptionsSnapshot<BusinessManagerClientOptions> optionsAccessor, HttpClient httpClient)
        {
            _config = optionsAccessor.Value;

            string host = _config.BaseAddress;
            string port = (string.IsNullOrEmpty(_config.Port)) ? "" : string.Concat(":", _config.Port);

            _apiUrl = _config.Version;

            string baseUri = string.Concat(host, port);

            //Logger.Verbose(this, $"NetConnectorClient HttpClient BaseAddress = {baseUri} api version = {_apiUrl}");

            httpClient.BaseAddress = new Uri(baseUri);
            //TODO Add authentication header
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json-patch+json");

            _client = httpClient;
        }

        /// <summary>
        /// Generic method for HttpClient DeleteAsync
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="url">Url string</param>
        /// <returns>No content</returns>
        /// <exception cref="ApiException">The request did not return a success http response code.</exception>
        public async Task DeleteAsync<T>(string url)
        {
            url = string.Concat(_apiUrl, url);
            T result = default(T);

            try
            {
                //Logger.Info(nameof(NetConnectorClient), $"GetAsync() client url {_client.BaseAddress}{url} return type {result}");

                using (HttpResponseMessage response = await _client.DeleteAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<T>();
                    }
                    else
                    {
                        throw await CreateApiException(response);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                //Logger.Error(nameof(NetConnectorClient), $"GetAsync HttpRequestException {ex.Message}", ex);
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(nameof(NetConnectorClient), $"GetAsync Exception {ex.Message}", ex);
                throw;
            }
        }

        /// <summary>
        /// Generic method for HttpClient GetAsync
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="url">Url string</param>
        /// <returns>Type provided</returns>
        /// <exception cref="ApiException">The request did not return a success http response code.</exception>
        public async Task<T> GetAsync<T>(string url)
        {
            url = string.Concat(_apiUrl, url);
            T result = default(T);

            try
            {
                //Logger.Info(nameof(NetConnectorClient), $"GetAsync() client url {_client.BaseAddress}{url} return type {result}");

                using (HttpResponseMessage response = await _client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<T>();
                    }
                    else
                    {
                        throw await CreateApiException(response);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                //Logger.Error(nameof(NetConnectorClient), $"GetAsync HttpRequestException {ex.Message}", ex);
                throw;
            }
            catch (Exception ex)
            {
               // Logger.Error(nameof(NetConnectorClient), $"GetAsync Exception {ex.Message}", ex);
                throw;
            }

            //// Return the Response
            return result;
        }

        /// <summary>
        /// Generic method for HttpClient PostAsync
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="url">Url string</param>
        /// <returns>Type provided</returns>
        /// <exception cref="ApiException">The request did not return a success http response code.</exception>
        public async Task PostAsync<T>(string url, T client)
        {
            url = string.Concat(_apiUrl, url);
            T result = default(T);

            try
            {
                //Logger.Info(nameof(NetConnectorClient), $"GetAsync() client url {_client.BaseAddress}{url} return type {result}");

                using (HttpResponseMessage response = await _client.PostAsJsonAsync<T>(url, client))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<T>();
                    }
                    else
                    {
                        throw await CreateApiException(response);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                //Logger.Error(nameof(NetConnectorClient), $"GetAsync HttpRequestException {ex.Message}", ex);
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(nameof(NetConnectorClient), $"GetAsync Exception {ex.Message}", ex);
                throw;
            }
        }

        /// <summary>
        /// Generic method for HttpClient PutAsync
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="url">Url string</param>
        /// <returns>Type provided</returns>
        /// <exception cref="ApiException">The request did not return a success http response code.</exception>
        public async Task PutAsync<T>(string url, T client)
        {
            url = string.Concat(_apiUrl, url);
            T result = default(T);

            try
            {
                //Logger.Info(nameof(NetConnectorClient), $"GetAsync() client url {_client.BaseAddress}{url} return type {result}");

                using (HttpResponseMessage response = await _client.PutAsJsonAsync<T>(url, client))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<T>();
                    }
                    else
                    {
                        throw await CreateApiException(response);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                //Logger.Error(nameof(NetConnectorClient), $"GetAsync HttpRequestException {ex.Message}", ex);
                throw;
            }
            catch (Exception ex)
            {
                // Logger.Error(nameof(NetConnectorClient), $"GetAsync Exception {ex.Message}", ex);
                throw;
            }

            //// Return the Response
        }

        /// <summary>
        /// Helper method for creating api exceptions
        /// </summary>
        /// <param name="response">An HttpResponseMessage</param>
        /// <returns>ApiResponseException</returns>
        private async Task<ApiException> CreateApiException(HttpResponseMessage response)
        {
            string apiMessage = "";

            if (response.Content != null)
            {
                apiMessage = await response.Content.ReadAsStringAsync();
            }

            apiMessage = GetApiResponseErrorMessage(response.StatusCode, apiMessage);

            return new ApiException(apiMessage, response.StatusCode);
        }

        /// <summary>
        /// Provide an error message for a status code if available
        /// </summary>
        /// <param name="StatusCode">The web api response status code</param>
        /// <param name="msg">The exception message</param>
        /// <returns>The passed in message or a message from the configuration file</returns>
        private string GetApiResponseErrorMessage(HttpStatusCode StatusCode, string msg = "")
        {
            string resultMsg = msg;

            switch (StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                    resultMsg = _config.E500InternalServerError;
                    break;
            }

            // log if the message was replaced
            if (!resultMsg.Equals(msg))
            {
                //Logger.Info(this, $"SetApiResponseErrorMessage() HttpStatusCode {StatusCode} replaced message {msg} with {resultMsg}");
            }

            return resultMsg;
        }
    }
}
