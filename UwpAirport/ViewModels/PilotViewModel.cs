using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UwpAirport.Models;
using UwpAirport.Services;

namespace UwpAirport.ViewModels
{
    public class PilotViewModel : BaseViewModel
    {
        private PilotService service;
        public Pilot SelectedItem { get; set; }

        public ObservableCollection<Pilot> Pilots { get; set; } = new ObservableCollection<Pilot>();

        public PilotViewModel()
        {
            service = new PilotService();
        }

        public async Task UpdateList()
        {
            var newCollection = new ObservableCollection<Pilot>(await service.GetAll());
            Pilots.Clear();
            foreach (var item in newCollection)
            {
                Pilots.Add(item);
            }
        }

        public async Task Create(Pilot pilot)
        {
            await service.Create(pilot);
            await UpdateList();
        }

        public async Task UpdateSelected(Pilot pilot)
        {
            await service.Update(SelectedItem.Id, pilot);
            SelectedItem = null;
            await UpdateList();
        }

        public async Task RemoveSelected()
        {
            await service.Delete(SelectedItem.Id);
            SelectedItem = null;
            await UpdateList();
        }

        public bool Valid(Pilot pilot)
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