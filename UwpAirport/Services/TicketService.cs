using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UwpAirport.Models;

namespace UwpAirport.Services
{
    public class TicketService
    {
        private string endpoint = Constants.Localhost + "tickets";
        HttpClient _httpclient = new HttpClient();

        public async Task<ObservableCollection<Ticket>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(endpoint);
            return JsonConvert.DeserializeObject<ObservableCollection<Ticket>>(result);
        }

        public async Task<Ticket> Get(int id)
        {
            string result = await _httpclient.GetStringAsync($"{endpoint}/{id}");
            return JsonConvert.DeserializeObject<Ticket>(result);
        }

        public async Task Create(Ticket ticket)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(endpoint, stringContent).ConfigureAwait(false);
        }

        public async Task Update(int id, Ticket ticket)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync($"{endpoint}/{id}", stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync($"{endpoint}/{id}").ConfigureAwait(false);
        }
    }
}