using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UwpAirport.Models;
using UwpAirport.Services;

namespace UwpAirport.ViewModels
{
    public class StewardessViewModel
    {
        private readonly StewardessService _service;
        public Stewardess SelectedItem { get; set; }

        public ObservableCollection<Stewardess> Stewardesses { get; set; } = new ObservableCollection<Stewardess>();

        public StewardessViewModel()
        {
            _service = new StewardessService();
        }

        public async Task UpdateList()
        {
            var newCollection = new ObservableCollection<Stewardess>(await _service.GetAll());
            Stewardesses.Clear();
            foreach (var item in newCollection)
            {
                Stewardesses.Add(item);
            }
        }

        public async Task Create(Stewardess stewardess)
        {
            await _service.Create(stewardess);
            await UpdateList();
        }

        public async Task UpdateSelected(Stewardess stewardess)
        {
            await _service.Update(SelectedItem.Id, stewardess);
            SelectedItem = null;
            await UpdateList();
        }

        public async Task RemoveSelected()
        {
            await _service.Delete(SelectedItem.Id);
            SelectedItem = null;
            await UpdateList();
        }

        public bool IsValid(Stewardess stewardess)
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