using System.Net;
using RestSharp;

namespace WunderGroundClient
{
    public partial class WunderGroundClient
    {
        private const string BaseUrl = "http://api.wunderground.com/api/";

        private readonly RestClient _client;
        private readonly string _clientId;

        public WunderGroundClient(string clientId)
            : this(clientId, new RestClient(BaseUrl))
        {
        }

        public WunderGroundClient(string clientId, RestClient restClient)
        {
            _client = restClient;
            _clientId = clientId;
        }

        private T ExectuteGet<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return default(T);
            }

            return response.Data;
        }
    }
}
