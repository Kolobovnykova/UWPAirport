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
         //   LoadItems();
            //Pilots = new ObservableCollection<Pilot>
            //{
            //    new Pilot { Id = 1, FirstName ="first name", LastName="last name", DateOfBirth = new DateTime(1990, 1,1), Experience = 3},
            //    new Pilot { Id = 2, FirstName ="first name", LastName="last name", DateOfBirth = new DateTime(1990, 1,1), Experience = 3},
            //    new Pilot { Id = 3, FirstName ="first name", LastName="last name", DateOfBirth = new DateTime(1990, 1,1), Experience = 3},
            //    new Pilot { Id = 4, FirstName ="first name", LastName="last name", DateOfBirth = new DateTime(1990, 1,1), Experience = 3},
            //    new Pilot { Id = 5, FirstName ="first name", LastName="last name", DateOfBirth = new DateTime(1990, 1,1), Experience = 3}
            //};
        }

        private async void LoadItems()
        {
            Pilots = await service.GetAll();
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
    }
}