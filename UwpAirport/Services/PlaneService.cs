using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UwpAirport.Models;

namespace UwpAirport.Services
{
    public class PlaneService
    {
        private string endpoint = Constants.Localhost + "planes";
        HttpClient _httpclient = new HttpClient();

        public async Task<ObservableCollection<Plane>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<ObservableCollection<Plane>>(result);
        }

        public async Task<Plane> Get(int id)
        {
            string result = await _httpclient.GetStringAsync($"{endpoint}/{id}");
            return JsonConvert.DeserializeObject<Plane>(result);
        }

        public async Task Create(Plane plane)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(plane), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(endpoint, stringContent).ConfigureAwait(false);
        }

        public async Task Update(int id, Plane plane)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(plane), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync($"{endpoint}/{id}", stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync($"{endpoint}/{id}").ConfigureAwait(false);
        }
    }
}