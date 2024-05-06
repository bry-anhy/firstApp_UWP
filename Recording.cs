using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
/// Example: Binding to a single item
/// Example: Bingding to a collection of items
///
namespace FirstAppUWP
{
    public class Recording
    {
        // Ten dien vien
        public string ArtistName { get; set; }

        // Bo phim
        public string CompositionName { get; set; }

        // Ngay phat hanh
        public DateTime ReleaseDateTime { get; set; }

        public Recording() {
            ArtistName = "Anh Y";
            CompositionName = "Hoc UWP";
            ReleaseDateTime = new DateTime(2024, 5, 6);
        }

        // Mo ta
        public string OneLineSummary
        {
            get
            {
                return $"{CompositionName} by {ArtistName}, release: " +
                    ReleaseDateTime.ToString("d");
            }
        }

        /// <summary>
        /// Every binding consists of a binding target and a binding source. 
        /// Typically, the target is a property of a control or other UI element, 
        /// and the source is a property of a class instance (a data model, or a view model)
        /// 
        /// 
        /// A common scenario is to bind to a collection of business objects. 
        /// In C#, the generic ObservableCollection<T> class is a good collection choice for data binding, 
        /// because it implements the INotifyPropertyChanged and INotifyCollectionChanged interfaces.
        /// </summary>
        public class RecordingViewModel
        {
            private Recording defaultRecording = new Recording();
            public Recording DefaultRecording { get { return defaultRecording;} }

            ///
            /// These interfaces provide change notification to bindings 
            /// when items are added or removed or a property of the list itself changes. 
            /// If you want your bound controls to update with changes to properties of objects in the collection, 
            /// the business object should also implement INotifyPropertyChanged. 
            /// For more info, see Data binding in depth.
            ///
            private ObservableCollection<Recording> recordings = new ObservableCollection<Recording>();
            public ObservableCollection<Recording> Recordings { get { return recordings; } }

            public RecordingViewModel() {
                recordings.Add(
                    new Recording() { ArtistName = "A1", CompositionName = "C1", ReleaseDateTime = new DateTime(2024, 05, 06) });

                recordings.Add(
                    new Recording() { ArtistName = "A2", CompositionName = "C2", ReleaseDateTime = new DateTime(2024, 05, 06) });

                recordings.Add(
                    new Recording() { ArtistName = "A3", CompositionName = "C3", ReleaseDateTime = new DateTime(2024, 05, 06) });
            }
        }
    }
}
