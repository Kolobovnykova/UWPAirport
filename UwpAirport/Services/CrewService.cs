using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UwpAirport.Models;

namespace UwpAirport.Services
{
    public class CrewService
    {
        private string endpoint = Constants.Localhost + "crews";
        HttpClient _httpclient = new HttpClient();

        public async Task<ObservableCollection<Crew>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<ObservableCollection<Crew>>(result);
        }

        public async Task<Crew> Get(int id)
        {
            string result = await _httpclient.GetStringAsync($"{endpoint}/{id}");
            return JsonConvert.DeserializeObject<Crew>(result);
        }

        public async Task Create(Crew crew)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(crew), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(endpoint, stringContent).ConfigureAwait(false);
        }

        public async Task Update(int id, Crew crew)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(crew), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync($"{endpoint}/{id}", stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync($"{endpoint}/{id}").ConfigureAwait(false);
        }
    }
}
