using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UwpAirport.Models;
using UwpAirport.Services;

namespace UwpAirport.ViewModels
{
    public class StewardessViewModel
    {
        private StewardessService service;
        public Stewardess SelectedItem { get; set; }

        public ObservableCollection<Stewardess> Stewardesses { get; set; } = new ObservableCollection<Stewardess>();

        public StewardessViewModel()
        {
            service = new StewardessService();
        }

        public async Task UpdateList()
        {
            var newCollection = new ObservableCollection<Stewardess>(await service.GetAll());
            Stewardesses.Clear();
            foreach (var item in newCollection)
            {
                Stewardesses.Add(item);
            }
        }

        public async Task Create(Stewardess stewardess)
        {
            await service.Create(stewardess);
            await UpdateList();
        }

        public async Task UpdateSelected(Stewardess stewardess)
        {
            await service.Update(SelectedItem.Id, stewardess);
            SelectedItem = null;
            await UpdateList();
        }

        public async Task RemoveSelected()
        {
            await service.Delete(SelectedItem.Id);
            SelectedItem = null;
            await UpdateList();
        }

        public bool Valid(Stewardess stewardess)
        {
            if (stewardess.FirstName == "" || stewardess.LastName == ""
                                           || stewardess.CrewId < 0 || stewardess.DateOfBirth > DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}