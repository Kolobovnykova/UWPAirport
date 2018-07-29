using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpAirport.Models;

namespace UwpAirport.ViewModels
{
    public class AcademyViewModel : BaseViewModel
    {
        private Academy _academy;

        public AcademyViewModel()
        {
            Title = "Academy";
            _academy = new Academy();
            SearchFilter = "";
            Students = new ObservableCollection<Student>();
            Search();
        }

        private string _searchFilter;
        public string SearchFilter
        {
            get { return _searchFilter; }
            set
            {
                _searchFilter = value;
                NotifyPropertyChanged(() => SearchFilter);
            }
        }

        public ObservableCollection<Student> Students { get; private set; }

        public void Search()
        {
            Students.Clear();
            if (string.IsNullOrWhiteSpace(SearchFilter))
            {
                foreach (var student in _academy.GetAllStudents())
                {
                    Students.Add(student);
                }
            }
            else
            {
                foreach (var student in _academy.GetByStudentName(SearchFilter))
                {
                    Students.Add(student);
                }
                foreach (var student in _academy.GetByStudentCity(SearchFilter))
                {
                    Students.Add(student);
                }
            }
        }
    }
}
