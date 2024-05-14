using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FirstAppUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Debug.WriteLine("MainPage");
            // This is a static public property that allows downstream pages to get a handle to the MainPage instance
            // in order to call methods that are in this class.
            Current = this;
            TbSampleTitle.Text = FEATURE_NAME;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("OnNavigatedTo");
            // Populate the scenario list from the SampleConfiguration.cs file
            LbScenarioControl.ItemsSource = scenarios;
            if (Window.Current.Bounds.Width < 640)
            {
                LbScenarioControl.SelectedIndex = -1;
            }
            else
            {
                LbScenarioControl.SelectedIndex = 0;
            }

            // This page is always at the top of our in-app back stack.
            // Once it is reached there is no further back so we can always disable the title bar back UI when navigated here.
            // If you want to you can always to the Frame.CanGoBack check for all your pages and act accordingly.
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        /// <summary>
        /// Called whenever the user changes selection in the scenarios list.
        /// This method will navigate to the respective
        /// sample scenario page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbScenarioControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("LbScenarioControl_SelectionChanged");
            // Clear the status block when navigating scenarios.
            NotifyUser(String.Empty, NotifyType.StatusMessage);

            ListBox scenarioListBox = sender as ListBox;
            Scenario s = scenarioListBox.SelectedItem as Scenario;
            if (s != null)
            {
                FrScenarioFrame.Navigate(s.ClassType);
                if (Window.Current.Bounds.Width < 640)
                {
                    SvSample.IsPaneOpen = false;
                }
            }
        }

        /// <summary>
        /// Hyperlink Footer click event
        /// * Launch Uri by tag (hyperlinkbutton)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void HlbFooter_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("HlbFooter_Click");
            await Windows.System.Launcher.LaunchUriAsync(new Uri(((HyperlinkButton) sender).Tag.ToString()));
        }

        private void HlbPrivacryLink_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("HlbPrivacryLink_Click");
            HlbFooter_Click(sender, e);
        }

        /// <summary>
        /// Header panel button click event
        /// * Show/ hide SplitView: SvSample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TgbHeaderPanelButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("TgbHeaderPanelButton_Click");
            SvSample.IsPaneOpen = !SvSample.IsPaneOpen;
        }

        #region Method
        /// <summary>
        /// Used to display messages to the user
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="type"></param>
        public void NotifyUser(string strMessage, NotifyType type)
        {
            Debug.WriteLine("NotifyUser");
            switch (type)
            {
                case NotifyType.StatusMessage:
                    BdStatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    break;
                case NotifyType.ErrorMessage:
                    BdStatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;
            }
            TbStatusBlock.Text = strMessage;

            // Collapse the StatusBlock if it has no text to conserve real estate.
            BdStatusBorder.Visibility = (TbStatusBlock.Text != String.Empty) ? Visibility.Visible : Visibility.Collapsed;
            if (TbStatusBlock.Text != String.Empty)
            {
                BdStatusBorder.Visibility = Visibility.Visible;
                SpStatusPanel.Visibility = Visibility.Visible;
            }
            else
            {
                BdStatusBorder.Visibility = Visibility.Collapsed;
                SpStatusPanel.Visibility = Visibility.Collapsed;
            }
        }
        #endregion Method
    }
}
