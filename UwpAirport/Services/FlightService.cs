using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UwpAirport.Models;

namespace UwpAirport.Services
{
    public class FlightService
    {
        private string endpoint = Constants.Localhost + "flights";
        HttpClient _httpclient = new HttpClient();

        public async Task<ObservableCollection<Flight>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<ObservableCollection<Flight>>(result);
        }

        public async Task<Flight> Get(int id)
        {
            string result = await _httpclient.GetStringAsync($"{endpoint}/{id}");
            return JsonConvert.DeserializeObject<Flight>(result);
        }

        public async Task Create(Flight flight)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(flight), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(endpoint, stringContent).ConfigureAwait(false);
        }

        public async Task Update(int id, Flight flight)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(flight), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync($"{endpoint}/{id}", stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync($"{endpoint}/{id}").ConfigureAwait(false);
        }
    }
}