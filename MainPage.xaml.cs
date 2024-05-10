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

            // This is a static public property that allows downstream pages to get a handle to the MainPage instance
            // in order to call methods that are in this class.
            TbSampleTitle.Text = FEATURE_NAME;

        }

        private void LbScenarioControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Hyperlink Footer click event
        /// * Launch Uri by tag (hyperlinkbutton)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void HlbFooter_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri(((HyperlinkButton) sender).Tag.ToString()));
        }

        private void HlbPrivacryLink_Click(object sender, RoutedEventArgs e)
        {
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
            SvSample.IsPaneOpen = !SvSample.IsPaneOpen;
        }
    }
}
