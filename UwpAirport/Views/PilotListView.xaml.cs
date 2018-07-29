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
            Form.Visibility = Visibility.Collapsed;
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
                    DateOfBirth = birthDatePicker.Date.Date,
                    Experience = Int32.Parse(formExperience.Text)
                };
                if (ViewModel.Valid(pilot))
                {
                    if ((string)Save.Content == "Create")
                    {
                        await ViewModel.Create(pilot);
                        WrongInput.Visibility = Visibility.Collapsed;
                        Form.Visibility = Visibility.Collapsed;
                        return;
                    }
                    else
                    {
                        await ViewModel.UpdateSelected(pilot);
                        WrongInput.Visibility = Visibility.Collapsed;
                        return;
                    }
                }
            }
            WrongInput.Visibility = Visibility.Visible;
        }

        public void ShowForm_Click(object sender, RoutedEventArgs e)
        {
            WrongInput.Visibility = Visibility.Collapsed;
            Form.Visibility = Visibility.Visible;
            FormTitle.Text = "New Pilot";
            formSurname.Text = "";
            DatePicker birthDatePicker = new DatePicker();
            birthDatePicker.Date = new DateTimeOffset(DateTime.Now);
            birthDatePicker.Header = "Date of birth";
            formName.Text = "";
            formExperience.Text = "";
            Save.Content = "Create";
            Delete.Visibility = Visibility.Collapsed;
        }

        private void ShowUpdateForm_Click(object sender, SelectionChangedEventArgs e)
        {
            var item = ((sender as ListView).SelectedItem as Models.Pilot);

            if (item == null)
            {
                return;
            }
            ViewModel.SelectedItem = item;

            WrongInput.Visibility = Visibility.Collapsed;
            Form.Visibility = Visibility.Visible;
            FormTitle.Text = "Details:";
            formName.Text = ViewModel.SelectedItem.FirstName;
            birthDatePicker.Date = new DateTimeOffset(ViewModel.SelectedItem.DateOfBirth);
            formSurname.Text = ViewModel.SelectedItem.LastName.ToString();
            formExperience.Text = ViewModel.SelectedItem.Experience.ToString();
            Save.Content = "Update";
            Delete.Visibility = Visibility.Visible;
        }


        private void GoToFlights(object sender, RoutedEventArgs e)
        {
            //   Frame.Navigate(typeof(FlightLogic));
        }
        private void GoToPilots(object sender, RoutedEventArgs e)
        {
            //  Frame.Navigate(typeof(PilotLogic));
        }

        private void GoToPlanes(object sender, RoutedEventArgs e)
        {
            // Frame.Navigate(typeof(PlaneLogic));
        }

        private void GoToPlanetypes(object sender, RoutedEventArgs e)
        {
            // Frame.Navigate(typeof(PlaneTypeLogic));
        }

        private void GoToStewardesses(object sender, RoutedEventArgs e)
        {
            // Frame.Navigate(typeof(StewardessLogic));
        }

        private void GoToTickets(object sender, RoutedEventArgs e)
        {
            //  Frame.Navigate(typeof(TicketLogic));
        }

    }
}
