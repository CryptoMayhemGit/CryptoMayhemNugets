using Mayhem.HttpClient.Interfaces;
using Mayhem.Messages;
using Mayhem.Util.Classes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mayhem.HttpClient.Implementation
{
    public class HttpClientService : IHttpClientService
    {
        private const string JsonMediaType = "application/json";
        private const string TimeoutPropertyKey = "RequestTimeout";
        private const string HttpClientServicePostTimeout = "30000";

        private readonly ILogger<HttpClientService> logger;

        private System.Net.Http.HttpClient httpClient;

        public HttpClientService(
            ILogger<HttpClientService> logger,
            IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            httpClient = httpClientFactory.CreateClient();

            SetCommonClientHeaders(httpClient);
        }

        public void InjectTestHttpClient(System.Net.Http.HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri, string accessToken = null, IDictionary<string, string> headers = null)
        {
            logger.LogDebug(LoggerMessages.HttpGetAsJsonAsyncNoRequest(requestUri));
            HttpMethod httpMethod = HttpMethod.Get;
            using HttpResponseMessage httpResponseMessage = await HttpSubmitJsonStringAsync(requestUri, string.Empty, httpMethod, accessToken, headers).ConfigureAwait(false);
            return httpResponseMessage;
        }

        public async Task<ActionDataResult<Tresponse>> HttpGetAsJsonAsync<Tresponse>(string requestUri,
                                                                                     string accessToken = null,
                                                                                     IDictionary<string, string> headers = null)
           where Tresponse : class
        {
            logger.LogDebug(LoggerMessages.HttpGetAsJsonAsyncNoRequest(requestUri));

            ActionDataResult<Tresponse> result = new();
            try
            {
                HttpMethod httpMethod = HttpMethod.Get;
                using HttpResponseMessage httpResponseMessage = await HttpSubmitJsonStringAsync(requestUri, string.Empty, httpMethod, accessToken, headers).ConfigureAwait(false);
                await GetResult(result, httpResponseMessage);

                result.StatusCode = httpResponseMessage.StatusCode;
                result.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Exception ex = new($"HttpGetAsJsonAsyncNoRequest {requestUri}. Errors : {e}");
                logger.LogError(ex, LoggerMessages.HttpClientHttpGetAsJsonAsyncNoRequestException);

                throw;
            }
            return result;
        }

        public async Task<ActionDataResult<Tresponse>> HttpPostAsJsonAsync<Tresponse>(string requestUri,
                                                                                      string accessToken = null,
                                                                                      IDictionary<string, string> headers = null)
            where Tresponse : class
        {
            logger.LogDebug(LoggerMessages.HttpPostAsJsonAsyncNoRequest(requestUri));

            ActionDataResult<Tresponse> result = new();

            try
            {
                HttpMethod httpMethod = HttpMethod.Post;
                using HttpResponseMessage httpResponseMessage = await HttpSubmitJsonStringAsync(requestUri, string.Empty, httpMethod, accessToken, headers).ConfigureAwait(false);
                await GetResult(result, httpResponseMessage);

                result.StatusCode = httpResponseMessage.StatusCode;
                result.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Exception ex = new($"HttpPostAsJsonAsyncNoRequest {requestUri}. Errors : {e}");
                logger.LogError(ex, LoggerMessages.HttpClientHttpPostAsJsonAsyncNoRequestException);
                throw;
            }

            return result;
        }

        public async Task<ActionDataResult<Tresponse>> HttpPostAsJsonAsync<Trequest, Tresponse>(string requestUri,
                                                                                                Trequest body,
                                                                                                string accessToken = null,
                                                                                                IDictionary<string, string> headers = null)
            where Trequest : class
            where Tresponse : class
        {
            logger.LogDebug(LoggerMessages.HttpPostAsJsonAsync(requestUri));

            ActionDataResult<Tresponse> result = new();

            try
            {
                HttpMethod httpMethod = HttpMethod.Post;
                string jsonBody = JsonConvert.SerializeObject(body);

                using HttpResponseMessage httpResponseMessage = await HttpSubmitJsonStringAsync(requestUri, jsonBody, httpMethod, accessToken, headers).ConfigureAwait(false);
                await GetResult(result, httpResponseMessage);

                result.StatusCode = httpResponseMessage.StatusCode;
                result.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;

            }
            catch (Exception e)
            {
                Exception ex = new($"HttpPostAsJsonAsync {requestUri}. Errors : {e}");
                logger.LogError(ex, LoggerMessages.HttpClientHttpPostAsJsonAsyncException);
                throw;
            }

            return result;
        }

        public async Task<ActionDataResult<Tresponse>> HttpPutAsJsonAsync<Trequest, Tresponse>(string requestUri,
                                                                                               Trequest body,
                                                                                               string accessToken = null,
                                                                                               IDictionary<string, string> headers = null)
            where Trequest : class
            where Tresponse : class
        {
            logger.LogDebug(LoggerMessages.HttpPutAsJsonAsync(requestUri));

            ActionDataResult<Tresponse> result = new();

            try
            {
                HttpMethod httpMethod = HttpMethod.Put;
                string jsonBody = JsonConvert.SerializeObject(body);

                using HttpResponseMessage httpResponseMessage = await HttpSubmitJsonStringAsync(requestUri, jsonBody, httpMethod, accessToken, headers).ConfigureAwait(false);
                await GetResult(result, httpResponseMessage);

                result.StatusCode = httpResponseMessage.StatusCode;
                result.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Exception ex = new($"HttpPutAsJsonAsync {requestUri}. Errors : {e}");
                logger.LogError(ex, LoggerMessages.HttpClientHttpPutAsJsonAsyncException);
                throw;
            }

            return result;
        }

        public async Task<ActionDataResult<Tresponse>> HttpDeleteAsJsonAsync<Tresponse>(string requestUri,
                                                                                        string accessToken = null,
                                                                                        IDictionary<string, string> headers = null) where Tresponse : class
        {
            logger.LogDebug(LoggerMessages.HttpDeleteAsJsonAsyncNoRequest(requestUri));

            ActionDataResult<Tresponse> result = new();

            try
            {
                HttpMethod httpMethod = HttpMethod.Delete;
                using HttpResponseMessage httpResponseMessage = await HttpSubmitJsonStringAsync(requestUri, string.Empty, httpMethod, accessToken, headers).ConfigureAwait(false);
                await GetResult(result, httpResponseMessage);

                result.StatusCode = httpResponseMessage.StatusCode;
                result.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Exception ex = new($"HttpDeleteAsJsonAsyncNoRequest {requestUri}. Errors : {e}");
                logger.LogError(ex, LoggerMessages.HttpClientHttpDeleteAsJsonAsyncNoRequestException);
                throw;
            }

            return result;
        }

        public async Task<ActionDataResult<Tresponse>> HttpDeleteAsJsonAsync<Trequest, Tresponse>(string requestUri,
                                                                                                  Trequest body,
                                                                                                  string accessToken = null,
                                                                                                  IDictionary<string, string> headers = null)
            where Trequest : class
            where Tresponse : class
        {
            logger.LogDebug(LoggerMessages.HttpDeleteAsJsonAsync(requestUri));

            ActionDataResult<Tresponse> result = new();

            try
            {
                HttpMethod httpMethod = HttpMethod.Delete;
                string jsonBody = JsonConvert.SerializeObject(body);

                using HttpResponseMessage httpResponseMessage = await HttpSubmitJsonStringAsync(requestUri, jsonBody, httpMethod, accessToken, headers).ConfigureAwait(false);
                await GetResult(result, httpResponseMessage);

                result.StatusCode = httpResponseMessage.StatusCode;
                result.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Exception ex = new($"HttpDeleteAsJsonAsync {requestUri}. Errors : {e}");
                logger.LogError(ex, LoggerMessages.HttpClientHttpDeleteAsJsonAsyncException);
                throw;
            }

            return result;
        }

        public async Task<ActionDataResult<Stream>> HttpGetAsStreamAsync(string requestUri,
                                                                         string accessToken = null,
                                                                         IDictionary<string, string> headers = null)
        {
            logger.LogDebug(LoggerMessages.HttpGetAsStreamAsync(requestUri));

            ActionDataResult<Stream> result = new();
            try
            {
                using HttpRequestMessage requestMessage = new(HttpMethod.Get, requestUri);
                AddAuthorizationHeader(requestMessage.Headers, accessToken);
                AddCustomHeaders(requestMessage.Headers, headers);
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    result.Result = await httpResponseMessage.Content.ReadAsStreamAsync();
                }
                else
                {
                    try
                    {
                        result.Errors = JsonConvert.DeserializeObject<ErrorResponse>(await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)).Errors;
                    }
                    catch (Exception)
                    {
                        result.Errors = await CreateCustomErrorMessage(httpResponseMessage);
                    }
                }

                result.StatusCode = httpResponseMessage.StatusCode;
                result.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Exception ex = new($"HttpGetAsStreamAsync {requestUri}. Errors : {e}");
                logger.LogError(ex, LoggerMessages.HttpClientHttpGetAsStreamAsyncException);
                throw;
            }

            return result;
        }

        public async Task<ActionDataResult<Stream>> HttpPostAsStreamAsync<Trequest>(string requestUri,
                                                                                    Trequest body,
                                                                                    string accessToken = null,
                                                                                    IDictionary<string, string> headers = null)
            where Trequest : class
        {
            logger.LogDebug(LoggerMessages.HttpPostAsStreamAsync(requestUri));

            ActionDataResult<Stream> result = new();
            try
            {
                HttpMethod httpMethod = HttpMethod.Post;
                string jsonBody = JsonConvert.SerializeObject(body);

                HttpResponseMessage httpResponseMessage = await HttpSubmitJsonStringAsync(requestUri, jsonBody, httpMethod, accessToken, headers).ConfigureAwait(false);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    result.Result = await httpResponseMessage.Content.ReadAsStreamAsync();
                }
                else
                {
                    try
                    {
                        result.Errors = JsonConvert.DeserializeObject<ErrorResponse>(await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)).Errors;
                    }
                    catch (Exception)
                    {
                        result.Errors = await CreateCustomErrorMessage(httpResponseMessage);
                    }
                }

                result.StatusCode = httpResponseMessage.StatusCode;
                result.IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Exception ex = new($"HttpPostAsStreamAsync {requestUri}. Errors : {e}");
                logger.LogError(ex, LoggerMessages.HttpClientHttpPostAsStreamAsyncException);
                throw;
            }

            return result;
        }

        private static void SetCommonClientHeaders(System.Net.Http.HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
            httpClient.DefaultRequestHeaders.ConnectionClose = false; //Connection: Keep - Alive

            httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/xml"));
            httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/json"));
        }

        private async Task<HttpResponseMessage> HttpSubmitJsonStringAsync(string requestUri,
                                                                          string stringBody,
                                                                          HttpMethod httpMethod,
                                                                          string accessToken,
                                                                          IDictionary<string, string> headers)
        {

            using StringContent stringContent = new(stringBody, Encoding.UTF8, JsonMediaType);
            using HttpRequestMessage request = new(httpMethod, requestUri)
            {
                Content = stringContent,
            };
            AddAuthorizationHeader(request.Headers, accessToken);
            AddCustomHeaders(request.Headers, headers);
            request.Options.Set(new HttpRequestOptionsKey<string>(TimeoutPropertyKey), HttpClientServicePostTimeout);
            return await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        }

        private static void AddAuthorizationHeader(HttpRequestHeaders httpHeaders,
                                            string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                httpHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }

        private static void AddCustomHeaders(HttpHeaders httpHeaders,
                                             IDictionary<string, string> headers)
        {
            if (headers == null)
            {
                return;
            }

            foreach (KeyValuePair<string, string> header in headers)
            {
                httpHeaders.Add(header.Key, header.Value);
            }
        }

        private static async Task GetResult<Tresponse>(ActionDataResult<Tresponse> result,
                                                HttpResponseMessage httpResponseMessage) where Tresponse : class
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                result.Result = JsonConvert.DeserializeObject<Tresponse>(await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false));
            }
            else
            {
                try
                {
                    result.Errors = JsonConvert.DeserializeObject<ErrorResponse>(await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)).Errors;
                }
                catch (Exception)
                {
                    result.Errors = await CreateCustomErrorMessage(httpResponseMessage);
                }
            }
        }

        private static async Task<List<ErrorModel>> CreateCustomErrorMessage(HttpResponseMessage httpResponseMessage)
        {
            return new List<ErrorModel>()
            {
                new ErrorModel("MessageParseError", await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false))
            };
        }
    }
}
