using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UwpAirport.Models;

namespace UwpAirport.Services
{
    public class PilotService
    {
        private string endpoint = "http://localhost:52062/api/pilots";
        HttpClient _httpclient = new HttpClient();

        public async Task<ObservableCollection<Pilot>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<ObservableCollection<Pilot>>(result);
        }

        public async Task<Pilot> Get(int id)
        {
            string result = await _httpclient.GetStringAsync($"{endpoint}/{id}");
            return JsonConvert.DeserializeObject<Pilot>(result);
        }

        public async Task Create(Pilot Pilot)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Pilot), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(endpoint, stringContent).ConfigureAwait(false);
        }

        public async Task Update(int id, Pilot Pilot)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Pilot), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync($"{endpoint}/{id}", stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync($"{endpoint}/{id}").ConfigureAwait(false);
        }
    }
}
