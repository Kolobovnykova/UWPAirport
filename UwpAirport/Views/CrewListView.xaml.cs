using System;
using UwpAirport.Models;
using UwpAirport.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpAirport.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CrewListView : Page
    {
        public CrewListView()
        {
            this.InitializeComponent();
            ViewModel = new CrewViewModel();
        }

        public CrewViewModel ViewModel { get; set; }

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
            bool isNumber = int.TryParse(pilotId.Text, out int n);
            bool isNumberStew = int.TryParse(stewardessId.Text, out int s);
            if (isNumber && isNumberStew)
            {
                CrewDTO crewDto = new CrewDTO
                {
                    PilotId = n,
                    StewardessId = s
                };
                if (ViewModel.IsValid(crewDto))
                {
                    if ((string)Save.Content == "Create")
                    {
                        await ViewModel.Create(crewDto);
                        WrongInput.Visibility = Visibility.Collapsed;
                        Form.Visibility = Visibility.Collapsed;
                        return;
                    }

                    await ViewModel.UpdateSelected(crewDto);
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
            FormTitle.Text = "New Crew";
            pilotId.Text = "";
            stewardessId.Text = "";
            Save.Content = "Create";
            Delete.Visibility = Visibility.Collapsed;
        }

        private void Update_Click(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView)?.SelectedItem as Crew;

            if (item == null)
            {
                return;
            }

            ViewModel.SelectedItem = new CrewDTO
            {
                Id = item.Id,
                PilotId = item.Pilot.Id,
                StewardessId = item.Stewardesses[0].Id
            };

            WrongInput.Visibility = Visibility.Collapsed;
            Form.Visibility = Visibility.Visible;
            FormTitle.Text = "Details:";
            pilotId.Text = ViewModel.SelectedItem.PilotId.ToString();
            stewardessId.Text = ViewModel.SelectedItem.StewardessId.ToString();
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

        private void Crews_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CrewListView));
        }
    }
}
