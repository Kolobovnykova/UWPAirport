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

        public ObservableCollection<Pilot> Pilots { get; set; } = new ObservableCollection<Pilot>();

        public PilotViewModel()
        {
            service = new PilotService();
        }

        private Pilot selected;
        public Pilot SelectedItem
        {
            get { return selected; }
            set
            {
                selected = value;
                if (selected != null)
                {
                    
                }

               // RaisePropertyChanged(() => SelectedPilot);
            }
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

        public async Task RemoveSelected()
        {
            await service.Delete(SelectedItem.Id);
            SelectedItem = null;
        }
    }
}