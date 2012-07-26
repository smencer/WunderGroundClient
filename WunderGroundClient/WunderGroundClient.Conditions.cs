using RestSharp;
using WunderGroundClient.Model;

namespace WunderGroundClient
{
    public partial class WunderGroundClient
    {
        private RestRequest getBaseRequest()
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = "/{key}/{features}/q/{query}.json"
            };

            return request;
        }

        public WunderGroundResponse GetCurrentConditionsByZip(string zipCode)
        {
            var request = getBaseRequest();

            request.AddParameter("key", _clientId, ParameterType.UrlSegment);
            request.AddParameter("features", "conditions", ParameterType.UrlSegment);
            request.AddParameter("query", zipCode, ParameterType.UrlSegment);

            return ExectuteGet<WunderGroundResponse>(request);
        }
    }
}
