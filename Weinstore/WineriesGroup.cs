using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Weinstore
{
    /// <summary>
    /// A list of lists
    /// </summary>

    public class WineriesGroup : ObservableCollection<Winery>, INotifyPropertyChanged
    {

        private bool _expanded;

        public string Title { get; set; }

        public string TitleWithItemCount
        {
            get { return string.Format("{0} ({1})", Title, WineryCount); }
        }

        public string ShortName { get; set; }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }

        public string StateIcon
        {
            get { return Expanded ? "baseline_keyboard_arrow_down_black_48pt_3x.png" : "baseline_keyboard_arrow_right_black_48pt_3x.png"; }
        }

        public int WineryCount { get; set; }

        public WineriesGroup(string title, string shortName, bool expanded = true)
        {
            Title = title;
            ShortName = shortName;
            Expanded = expanded;
        }

        public static ObservableCollection<WineriesGroup> All { private set; get; }

        static WineriesGroup()
        {
            ObservableCollection<WineriesGroup> Groups = new ObservableCollection<WineriesGroup>{
                new WineriesGroup("Südsteiermark","S"){
                    new Winery { Name = "Weingut Gamser", Description = "Weingut",  Icon="GamserLogo.png" },
                    new Winery { Name = "Weingut Strauss", Description = "Weingut", Icon="StraussLogo.png" },
                    new Winery { Name = "Weingut Kratzer", Description = "Weingut", Icon="KratzerLogo.png" },
                    new Winery { Name = "Weingut Gutjahr", Description = "Weingut", Icon="GutjahrLogo.png" },
                },
                new WineriesGroup("Vulkanland","V"){
                    new Winery { Name = "Weingut Gamser", Description = "Weingut",  Icon="GamserLogo.png" },
                    new Winery { Name = "Weingut Strauss", Description = "Weingut", Icon="StraussLogo.png" },
                    new Winery { Name = "Weingut Kratzer", Description = "Weingut", Icon="KratzerLogo.png" },
                    new Winery { Name = "Weingut Gutjahr", Description = "Weingut", Icon="GutjahrLogo.png" },
                },
                new WineriesGroup("Oststeiermark","O"){
                    new Winery { Name = "Weingut Gamser", Description = "Weingut",  Icon="GamserLogo.png" },
                    new Winery { Name = "Weingut Strauss", Description = "Weingut", Icon="StraussLogo.png" },
                    new Winery { Name = "Weingut Kratzer", Description = "Weingut", Icon="KratzerLogo.png" },
                    new Winery { Name = "Weingut Gutjahr", Description = "Weingut", Icon="GutjahrLogo.png" },
                }
            };
            All = Groups;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
