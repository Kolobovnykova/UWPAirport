using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UwpAirport.Models;

namespace UwpAirport.Services
{
    public class PilotService
    {
        private string endpoint = "http://localhost:52062/api/pilots";
        private HttpClient httpClient;

        public PilotService()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }
        }

        public async Task<ObservableCollection<Pilot>> GetAll()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint).ConfigureAwait(false);
                var data = await response.Content.ReadAsStringAsync();
                var items = JsonConvert.DeserializeObject<ObservableCollection<Pilot>>(data);
                return items;
            }
        }
    }
}
