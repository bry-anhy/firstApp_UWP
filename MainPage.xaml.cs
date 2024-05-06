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
using static FirstAppUWP.Recording;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FirstAppUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public RecordingViewModel ViewModel { get; set; }

        /// <summary>
        /// Next, expose the binding source class from the class that represents your window of markup. 
        /// We do that by adding a property of type RecordingViewModel to MainPage.xaml.cs.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            // bingding source class
            ViewModel = new RecordingViewModel();
        }
    }
}
