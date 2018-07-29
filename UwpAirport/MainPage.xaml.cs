using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UwpAirport.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpAirport
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void Pilots_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PilotListView));
        }

        private void Stewardesses_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AcademyView));
        }

        private void HandleCheck(object sender, RoutedEventArgs e) { 
            splitView.IsPaneOpen = true; 
        }
		
        private void HandleUnchecked(object sender, RoutedEventArgs e) {
            splitView.IsPaneOpen = false; 
        }
      
    }
}
