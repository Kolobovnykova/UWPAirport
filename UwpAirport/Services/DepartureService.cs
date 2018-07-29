using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UwpAirport.Models;

namespace UwpAirport.Services
{
    public class DepartureService
    {
        private string endpoint = Constants.Localhost + "departures";
        HttpClient _httpclient = new HttpClient();

        public async Task<ObservableCollection<Departure>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<ObservableCollection<Departure>>(result);
        }

        public async Task<Departure> Get(int id)
        {
            string result = await _httpclient.GetStringAsync($"{endpoint}/{id}");
            return JsonConvert.DeserializeObject<Departure>(result);
        }

        public async Task Create(Departure departure)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(departure), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(endpoint, stringContent).ConfigureAwait(false);
        }

        public async Task Update(int id, Departure departure)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(departure), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync($"{endpoint}/{id}", stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync($"{endpoint}/{id}").ConfigureAwait(false);
        }
    }
}