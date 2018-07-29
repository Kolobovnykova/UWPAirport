using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UwpAirport.ViewModels;
using UwpAirport.Models;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpAirport.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PilotListView : Page
    {
        public PilotListView()
        {
            this.InitializeComponent();
            ViewModel = new PilotViewModel();
        }

        public PilotViewModel ViewModel { get; set; }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.UpdateList();
        }

        public async void Delete_Click(object sender, RoutedEventArgs e)
        {
            Detail.Visibility = Visibility.Collapsed;
            await ViewModel.RemoveSelected();
        }

        public async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool isNumber = int.TryParse(formExperience.Text, out int n);
            if (isNumber)
            {
                Pilot pilot = new Pilot()
                {
                    FirstName = formName.Text,
                    LastName = formSurname.Text,
                    DateOfBirth = birthDatePicker.Date.DateTime,
                    Experience = Int32.Parse(formExperience.Text)
                };
                if (ViewModel.Valid(pilot))
                {
                    if (FormTitle.Text == "New Pilot")
                    {
                        await ViewModel.Create(pilot);
                        WrongInput.Visibility = Visibility.Collapsed;
                        return;
                    }
                    if (FormTitle.Text == "Edit Pilot")
                    {
                        await ViewModel.UpdateSelected(pilot);
                        WrongInput.Visibility = Visibility.Collapsed;
                        return;
                    }
                }
            }
            WrongInput.Visibility = Visibility.Visible;
        }

        public void ShowUpdateForm_Click(object sender, RoutedEventArgs e)
        {
            WrongInput.Visibility = Visibility.Collapsed;
            Form.Visibility = Visibility.Visible;
            FormTitle.Text = "Edit Pilot";
            formName.Text = ViewModel.SelectedItem.FirstName;
            birthDatePicker.Date = new DateTimeOffset(ViewModel.SelectedItem.DateOfBirth);
            formSurname.Text = ViewModel.SelectedItem.LastName.ToString();
            formExperience.Text = ViewModel.SelectedItem.Experience.ToString();
            save.Content = "Update";
            Detail.Visibility = Visibility.Collapsed;
        }

        public void ShowForm_Click(object sender, RoutedEventArgs e)
        {
            WrongInput.Visibility = Visibility.Collapsed;
            Form.Visibility = Visibility.Visible;
            FormTitle.Text = "New Pilot";
            formSurname.Text = "";
            DatePicker birthDatePicker = new DatePicker();
            birthDatePicker.Header = "Date of birth";
            formName.Text = "";
            save.Content = "Create";
            Detail.Visibility = Visibility.Collapsed;
        }

        public void SelectItem_Click(object sender, SelectionChangedEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem as Models.Pilot);
            ViewModel.SelectedItem = item;

            Form.Visibility = Visibility.Collapsed;
            Detail.Visibility = Visibility.Visible;
        }

        private void ShowFlights(object sender, RoutedEventArgs e)
        {
            //   Frame.Navigate(typeof(FlightLogic));
        }
        private void ShowPilots(object sender, RoutedEventArgs e)
        {
            //  Frame.Navigate(typeof(PilotLogic));
        }

        private void ShowPlanes(object sender, RoutedEventArgs e)
        {
            // Frame.Navigate(typeof(PlaneLogic));
        }

        private void ShowPlaneTypes(object sender, RoutedEventArgs e)
        {
            // Frame.Navigate(typeof(PlaneTypeLogic));
        }

        private void ShowStewardesses(object sender, RoutedEventArgs e)
        {
            // Frame.Navigate(typeof(StewardessLogic));
        }

        private void ShowTickets(object sender, RoutedEventArgs e)
        {
            //  Frame.Navigate(typeof(TicketLogic));
        }
    }
}
