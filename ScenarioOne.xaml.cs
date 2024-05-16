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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FirstAppUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScenarioOne : Page
    {
        #region property
        private static bool optedIn = false;
        private MainPage rootPage;
        #endregion property

        public ScenarioOne()
        {
            this.InitializeComponent();

            // i want this page to be always cached
            // so that we do not have to add logic to 
            // save/restore state for the checkbox
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            rootPage = MainPage.Current;
        }

        private void CkEnableBack_Checked(object sender, RoutedEventArgs e)
        {
            optedIn = !optedIn;
        }

        private void CkEnableBack_Unchecked(object sender, RoutedEventArgs e)
        {
            CkEnableBack_Checked(sender,e);
        }

        /// <summary>
        /// Navigate to Secondary page click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNavigateToSecondaryPage_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // navigate to the next page, with info in the parameters
            // wheter to enable the title bar UI or not
            rootFrame.Navigate(typeof(SecondaryPage), optedIn);
        }
    }
}
