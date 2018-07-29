using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UwpAirport.Models;

namespace UwpAirport.Services
{
    public class StewardessService
    {
        private string endpoint = Constants.Localhost + "stewardesses";
        HttpClient _httpclient = new HttpClient();

        public async Task<ObservableCollection<Stewardess>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<ObservableCollection<Stewardess>>(result);
        }

        public async Task<Stewardess> Get(int id)
        {
            string result = await _httpclient.GetStringAsync($"{endpoint}/{id}");
            return JsonConvert.DeserializeObject<Stewardess>(result);
        }

        public async Task Create(Stewardess stewardess)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(stewardess), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(endpoint, stringContent).ConfigureAwait(false);
        }

        public async Task Update(int id, Stewardess stewardess)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(stewardess), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync($"{endpoint}/{id}", stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync($"{endpoint}/{id}").ConfigureAwait(false);
        }
    }
}