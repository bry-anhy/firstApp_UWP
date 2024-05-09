using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
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

            // By default, the title bar shows the app's display name as the window title.
            // The display name is set in the Package.appxmanifest file.
            // To add custom text to the title, set the ApplicationView.Title property to a text value, as shown here.
            ApplicationView.GetForCurrentView().Title = "Custom text";

            ////////////////////////////////////////////////////////////
            // The button background color is not applied to the close button hover and pressed states.
            // The close button always uses the system-defined color for those states.
            // Setting a color property to null resets it to the default system color.
            // You can't set transparent colors. The color's alpha channel is ignored.

            // using Windows.UI;
            // using Windows.UI.ViewManagement;
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            // Set active window colors
            titleBar.ForegroundColor = Colors.White;
            titleBar.BackgroundColor = Colors.Green;
            titleBar.ButtonForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Colors.SeaGreen;
            titleBar.ButtonHoverForegroundColor = Colors.White;
            titleBar.ButtonHoverBackgroundColor = Colors.DarkSeaGreen;
            titleBar.ButtonPressedForegroundColor = Colors.Gray;
            titleBar.ButtonPressedBackgroundColor = Colors.LightGreen;

            // Set inactive window colors
            titleBar.InactiveForegroundColor = Colors.Gainsboro;
            titleBar.InactiveBackgroundColor = Colors.SeaGreen;
            titleBar.ButtonInactiveForegroundColor = Colors.Gainsboro;
            titleBar.ButtonInactiveBackgroundColor = Colors.SeaGreen;
            ////////////////////////////////////////////////////////////


            ////////////////////////////////////////////////////////////
            // Hide default title bar.
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            ////////////////////////////////////////////////////////////
            
            // Set XAML element as a drag region.
            Window.Current.SetTitleBar(AppTitleBar);

            AppTitleTextBlock.Text = AppInfo.Current.DisplayInfo.DisplayName;
        }
    }
}
