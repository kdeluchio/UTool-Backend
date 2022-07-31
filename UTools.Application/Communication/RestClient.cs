using System.Net.Http;
using System.Threading.Tasks;

namespace UTools.Application.Communication
{

    public class RestClient
    {
        private static HttpClient client = null;
        private static RestClient singlenton = null;

        public static RestClient GetInstance()
        {
            if (singlenton == null)
            {
                singlenton = new RestClient();
            }

            return singlenton;
        }

        private RestClient()
        {
            client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string uriApi) where T : class
        {
            HttpResponseMessage response = await client.GetAsync(uriApi);
            return await response.Content.ReadAsAsync<T>();
        }


    }
}
