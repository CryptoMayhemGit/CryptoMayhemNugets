using Mayhem.Util.Classes;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mayhem.HttpClient.Interfaces
{
    /// <summary>
    /// Http client service
    /// </summary>
    public interface IHttpClientService
    {
        /// <summary>
        /// Injects the test HTTP client.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        void InjectTestHttpClient(System.Net.Http.HttpClient httpClient);
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(string requestUri, string accessToken = null, IDictionary<string, string> headers = null);
        /// <summary>
        /// HTTPs the get as json asynchronous.
        /// </summary>
        /// <typeparam name="Tresponse">The type of the response.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        Task<ActionDataResult<Tresponse>> HttpGetAsJsonAsync<Tresponse>(string requestUri, string accessToken = null, IDictionary<string, string> headers = null) where Tresponse : class;

        /// <summary>
        /// HTTPs the post as json asynchronous.
        /// </summary>
        /// <typeparam name="Trequest">The type of the request.</typeparam>
        /// <typeparam name="Tresponse">The type of the response.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="body">The body.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        Task<ActionDataResult<Tresponse>> HttpPostAsJsonAsync<Trequest, Tresponse>(string requestUri, Trequest body, string accessToken = null, IDictionary<string, string> headers = null) where Trequest : class where Tresponse : class;

        /// <summary>
        /// HTTPs the post as json asynchronous.
        /// </summary>
        /// <typeparam name="Tresponse">The type of the response.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        Task<ActionDataResult<Tresponse>> HttpPostAsJsonAsync<Tresponse>(string requestUri, string accessToken = null, IDictionary<string, string> headers = null) where Tresponse : class;

        /// <summary>
        /// HTTPs the put as json asynchronous.
        /// </summary>
        /// <typeparam name="Trequest">The type of the request.</typeparam>
        /// <typeparam name="Tresponse">The type of the response.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="body">The body.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        Task<ActionDataResult<Tresponse>> HttpPutAsJsonAsync<Trequest, Tresponse>(string requestUri, Trequest body, string accessToken = null, IDictionary<string, string> headers = null) where Trequest : class where Tresponse : class;

        /// <summary>
        /// HTTPs the delete as json asynchronous.
        /// </summary>
        /// <typeparam name="Trequest">The type of the request.</typeparam>
        /// <typeparam name="Tresponse">The type of the response.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="body">The body.</param>
        /// <param name="accessToken">The access token to be set in authorization header.</param>
        /// <param name="headers">Custom request headers.</param>
        /// <returns></returns>
        Task<ActionDataResult<Tresponse>> HttpDeleteAsJsonAsync<Trequest, Tresponse>(string requestUri, Trequest body, string accessToken = null, IDictionary<string, string> headers = null)
            where Trequest : class
            where Tresponse : class;

        /// <summary>
        /// HTTPs the delete as json asynchronous.
        /// </summary>
        /// <typeparam name="Tresponse">The type of the response.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="accessToken">The access token to be set in authorization header.</param>
        /// <param name="headers">Custom request headers.</param>
        /// <returns></returns>
        Task<ActionDataResult<Tresponse>> HttpDeleteAsJsonAsync<Tresponse>(string requestUri, string accessToken = null, IDictionary<string, string> headers = null) where Tresponse : class;

        /// <summary>
        /// HTTPs the post as stream asynchronous.
        /// </summary>
        /// <typeparam name="Trequest">The type of the request.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="body">The body.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        Task<ActionDataResult<Stream>> HttpPostAsStreamAsync<Trequest>(string requestUri, Trequest body, string accessToken = null, IDictionary<string, string> headers = null) where Trequest : class;


        /// <summary>
        /// HTTPs get stream asynchronous.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="accessToken">The access token to be set in authorization header.</param>
        /// <param name="headers">Custom request headers.</param>
        /// <returns></returns>
        Task<ActionDataResult<Stream>> HttpGetAsStreamAsync(string requestUri, string accessToken = null, IDictionary<string, string> headers = null);
    }
}
