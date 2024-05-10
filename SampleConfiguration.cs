using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace FirstAppUWP
{
    internal class SampleConfiguration
    {
    }

    public partial class MainPage : Page
    {
        public const string FEATURE_NAME = "SystemBack";

        public List<Scenario> scenarios = new List<Scenario>()
        {
            new Scenario()
            {
                Title = "Subscrible to the BackRequested event",
                ClassType = typeof(ScenarioOne)
            }
        };

        public List<Scenario> Scenarios
        {
            get { return this.scenarios; }
        }

        public static MainPage Current;
    }

    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }

    public enum NotifyType
    {
        StatusMessage,
        ErrorMessage
    }

    public class ScenarioBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Scenario s = value as Scenario;
            return (MainPage.Current.Scenarios.IndexOf(s) + 1) + ") " + s.Title;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return true;
        }
    }
}
