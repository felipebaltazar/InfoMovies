using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoMovies.Helpers
{
    public sealed class WebApiClient : IDisposable
    {
        #region Read only

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructors

        public WebApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Public Methods

        public async Task<T> GetAsync<T>(string requestUri)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                AddHeaders(request);

                try
                {
                    using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        try
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<T>(result);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.LogException(ex);
                            return default(T);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogException(ex);
                    return default(T);
                }
            }
        }

        public async Task<Stream> GetStreamAsync(string requestUri)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                AddHeaders(request);

                try
                {
                    using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        try
                        {
                            return await response.Content.ReadAsStreamAsync();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.LogException(ex);
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogException(ex);
                    return null;
                }
            }
        }

        #endregion

        #region IDisposable

        public void Dispose() =>
            _httpClient.Dispose();

        #endregion

        #region Private Methods

        private void AddHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("cache-control", "no-cache");
        }

        #endregion
    }
}