using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UwpAirport.Models;
using UwpAirport.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpAirport.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StewardessListView : Page
    {
        public StewardessListView()
        {
            this.InitializeComponent();

            ViewModel = new StewardessViewModel();
        }

        public StewardessViewModel ViewModel { get; set; }

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
            bool isNumber = int.TryParse(crewId.Text, out int n);
            if (isNumber)
            {
                Stewardess stewardess = new Stewardess
                {
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    DateOfBirth = birthDatePicker.Date.Date,
                    CrewId = n
                };
                if (ViewModel.Valid(stewardess))
                {
                    if ((string) Save.Content == "Create")
                    {
                        await ViewModel.Create(stewardess);
                        WrongInput.Visibility = Visibility.Collapsed;
                        Form.Visibility = Visibility.Collapsed;
                        return;
                    }

                    await ViewModel.UpdateSelected(stewardess);
                    WrongInput.Visibility = Visibility.Collapsed;
                    return;
                }
            }

            WrongInput.Visibility = Visibility.Visible;
        }

        public void AddNew_Click(object sender, RoutedEventArgs e)
        {
            WrongInput.Visibility = Visibility.Collapsed;
            Form.Visibility = Visibility.Visible;
            FormTitle.Text = "New Pilot";
            lastName.Text = "";
            birthDatePicker = new DatePicker
            {
                Date = new DateTimeOffset(DateTime.Now),
                Header = "Date of birth"
            };
            firstName.Text = "";
            crewId.Text = "";
            Save.Content = "Create";
            Delete.Visibility = Visibility.Collapsed;
        }

        private void Update_Click(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView)?.SelectedItem as Stewardess;

            if (item == null)
            {
                return;
            }

            ViewModel.SelectedItem = item;

            WrongInput.Visibility = Visibility.Collapsed;
            Form.Visibility = Visibility.Visible;
            FormTitle.Text = "Details:";
            firstName.Text = ViewModel.SelectedItem.FirstName;
            birthDatePicker.Date = new DateTimeOffset(ViewModel.SelectedItem.DateOfBirth);
            lastName.Text = ViewModel.SelectedItem.LastName;
            crewId.Text = ViewModel.SelectedItem.CrewId.ToString();
            Save.Content = "Update";
            Delete.Visibility = Visibility.Visible;
        }

        private void Flight_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PilotListView));
        }

        private void Pilots_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PilotListView));
        }

        private void Planes_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PilotListView));
        }

        private void PlaneTypes_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PilotListView));
        }

        private void Stewardesses_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StewardessListView));
        }

        private void Tickets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PilotListView));
        }
    }
}