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
using Windows.UI.Core;
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
        CoreApplicationViewTitleBar coreTitleBar;
        public MainPage()
        {
            this.InitializeComponent();

            //// By default, the title bar shows the app's display name as the window title.
            //// The display name is set in the Package.appxmanifest file.
            //// To add custom text to the title, set the ApplicationView.Title property to a text value, as shown here.
            //ApplicationView.GetForCurrentView().Title = "Custom text";

            //////////////////////////////////////////////////////////////
            //// The button background color is not applied to the close button hover and pressed states.
            //// The close button always uses the system-defined color for those states.
            //// Setting a color property to null resets it to the default system color.
            //// You can't set transparent colors. The color's alpha channel is ignored.

            //// using Windows.UI;
            //// using Windows.UI.ViewManagement;
            //var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            //// Set active window colors
            //titleBar.ForegroundColor = Colors.White;
            //titleBar.BackgroundColor = Colors.Green;
            //titleBar.ButtonForegroundColor = Colors.White;
            //titleBar.ButtonBackgroundColor = Colors.SeaGreen;
            //titleBar.ButtonHoverForegroundColor = Colors.White;
            //titleBar.ButtonHoverBackgroundColor = Colors.DarkSeaGreen;
            //titleBar.ButtonPressedForegroundColor = Colors.Gray;
            //titleBar.ButtonPressedBackgroundColor = Colors.LightGreen;

            //// Set inactive window colors
            //titleBar.InactiveForegroundColor = Colors.Gainsboro;
            //titleBar.InactiveBackgroundColor = Colors.SeaGreen;
            //titleBar.ButtonInactiveForegroundColor = Colors.Gainsboro;
            //titleBar.ButtonInactiveBackgroundColor = Colors.SeaGreen;
            //////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////
            //// Hide default title bar.
            //var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            //coreTitleBar.ExtendViewIntoTitleBar = true;
            //////////////////////////////////////////////////////////////

            //// Set XAML element as a drag region.
            //Window.Current.SetTitleBar(AppTitleBar);

            //AppTitleTextBlock.Text = AppInfo.Current.DisplayInfo.DisplayName;


            //////////////////////////////////////////////////////////////
            // Hide default title bar.
            coreTitleBar =
                CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            // Set caption buttons background to transparent.
            ApplicationViewTitleBar titleBar =
                ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;

            // Set XAML element as a drag region.
            Window.Current.SetTitleBar(AppTitleBar);

            // Register a handler for when the size of the overlaid caption control changes.
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;

            // Register a handler for when the title bar visibility changes.
            // For example, when the title bar is invoked in full screen mode.
            coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;

            // Register a handler for when the window activation changes.
            Window.Current.CoreWindow.Activated += CoreWindow_Activated;
            //////////////////////////////////////////////////////////////
        }

        #region Method
        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            // Get the size of the caption controls and set padding.
            //LeftPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayLeftInset);
            //RightPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayRightInset);
        }

        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            if (sender.IsVisible)
            {
                AppTitleBar.Visibility = Visibility.Visible;
            }
            else
            {
                AppTitleBar.Visibility = Visibility.Collapsed;
            }
        }

        private void CoreWindow_Activated(CoreWindow sender, WindowActivatedEventArgs args)
        {
            UISettings settings = new UISettings();
            if (args.WindowActivationState == CoreWindowActivationState.Deactivated)
            {
                AppTitleTextBlock.Foreground =
                   new SolidColorBrush(settings.UIElementColor(UIElementType.GrayText));
            }
            else
            {
                AppTitleTextBlock.Foreground =
                   new SolidColorBrush(settings.UIElementColor(UIElementType.WindowText));
            }
        }
        #endregion Method
    }
}
