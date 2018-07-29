using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UwpAirport.Models;

namespace UwpAirport.Services
{
    public class PlaneTypeService
    {
        private string endpoint = Constants.Localhost + "planetypes";
        HttpClient _httpclient = new HttpClient();

        public async Task<ObservableCollection<PlaneType>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<ObservableCollection<PlaneType>>(result);
        }

        public async Task<PlaneType> Get(int id)
        {
            string result = await _httpclient.GetStringAsync($"{endpoint}/{id}");
            return JsonConvert.DeserializeObject<PlaneType>(result);
        }

        public async Task Create(PlaneType planeType)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(planeType), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(endpoint, stringContent).ConfigureAwait(false);
        }

        public async Task Update(int id, PlaneType planeType)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(planeType), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync($"{endpoint}/{id}", stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync($"{endpoint}/{id}").ConfigureAwait(false);
        }
    }
}
