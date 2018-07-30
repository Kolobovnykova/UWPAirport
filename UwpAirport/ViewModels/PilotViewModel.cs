using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UwpAirport.Models;
using UwpAirport.Services;

namespace UwpAirport.ViewModels
{
    public class PilotViewModel : BaseViewModel
    {
        private readonly PilotService _service;
        public Pilot SelectedItem { get; set; }

        public ObservableCollection<Pilot> Pilots { get; set; } = new ObservableCollection<Pilot>();

        public PilotViewModel()
        {
            _service = new PilotService();
        }

        public async Task UpdateList()
        {
            var newCollection = new ObservableCollection<Pilot>(await _service.GetAll());
            Pilots.Clear();
            foreach (var item in newCollection)
            {
                Pilots.Add(item);
            }
        }

        public async Task Create(Pilot pilot)
        {
            await _service.Create(pilot);
            await UpdateList();
        }

        public async Task UpdateSelected(Pilot pilot)
        {
            await _service.Update(SelectedItem.Id, pilot);
            SelectedItem = null;
            await UpdateList();
        }

        public async Task RemoveSelected()
        {
            await _service.Delete(SelectedItem.Id);
            SelectedItem = null;
            await UpdateList();
        }

        public bool IsValid(Pilot pilot)
        {
            if (pilot.FirstName == "" || pilot.LastName == ""
                || pilot.Experience < 0 || pilot.DateOfBirth > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}