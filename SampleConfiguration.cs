using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FirstAppUWP
{
    internal class SampleConfiguration
    {
    }

    public partial class MainPage : Page
    {
        public const string FEATURE_NAME = "SystemBack";

        List<Scenario> scenarios = new List<Scenario>()
        {
            new Scenario()
            {
                Title = "Subscrible to the BackRequested event",
                ClassType = typeof(ScenarioOne)
            }
        };
    }

    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
}
