using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
/// Example: Binding to a single item
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
        /// </summary>
        public class RecordingViewModel
        {
            private Recording defaultRecording = new Recording();
            public Recording DefaultRecording { get { return defaultRecording;} }
        }
    }
}
