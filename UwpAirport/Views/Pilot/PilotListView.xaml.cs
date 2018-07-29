using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UwpAirport.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpAirport.Views.Pilot
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

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = true;
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
        }
    }
}
