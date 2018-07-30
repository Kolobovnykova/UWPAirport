using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UwpAirport.Models;
using UwpAirport.Services;

namespace UwpAirport.ViewModels
{
    public class CrewViewModel : BaseViewModel
    {
        private readonly CrewService _service;
        private readonly PilotService _pilotService;
        private readonly StewardessService _stewardessService;
        public CrewDTO SelectedItem { get; set; }

        public ObservableCollection<Crew> Crews { get; set; } = new ObservableCollection<Crew>();

        public CrewViewModel()
        {
            _service = new CrewService();
            _pilotService = new PilotService();
            _stewardessService = new StewardessService();
        }

        public async Task UpdateList()
        {
            var newCollection = new ObservableCollection<Crew>(await _service.GetAll());
            Crews.Clear();
            foreach (var item in newCollection)
            {
                Crews.Add(item);
            }
        }

        public async Task Create(CrewDTO crewDto)
        {
            Pilot pilot;
            Stewardess stewardess;
            try
            {
                pilot = await _pilotService.Get(crewDto.PilotId);
                stewardess = await _stewardessService.Get(crewDto.StewardessId);
            }
            catch (System.Exception)
            {
                return;
            }
            pilot.Id = 0;
            stewardess.Id = 0;

            Crew crew = new Crew
            {
                Pilot = pilot,
                Stewardesses = new List<Stewardess>
                {
                    stewardess
                }
            };

            await _service.Create(crew);
            await UpdateList();
        }

        public async Task UpdateSelected(CrewDTO crewDto)
        {
            var crew = await _service.Get(SelectedItem.Id);
            Pilot pilot;
            Stewardess stewardess;
            try
            {
                pilot = await _pilotService.Get(crewDto.PilotId);
                stewardess = await _stewardessService.Get(crewDto.StewardessId);
            }
            catch (System.Exception)
            {
                return;
            }
            pilot.Id = 0;
            stewardess.Id = 0;

            crew.Pilot = pilot;
            crew.Stewardesses = new List<Stewardess>
            {
                stewardess
            };

            await _service.Update(SelectedItem.Id, crew);
            SelectedItem = null;
            await UpdateList();
        }

        public async Task RemoveSelected()
        {
            await _service.Delete(SelectedItem.Id);
            SelectedItem = null;
            await UpdateList();
        }

        public bool IsValid(CrewDTO crew)
        {
            if (crew.PilotId <= 0 || crew.StewardessId <= 0)
            {
                return false;
            }

            return true;
        }
    }
}