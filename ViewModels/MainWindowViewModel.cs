using ProductMonitor.UserControls;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProductMonitor.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private UserControl _monitorUC = new MonitorUC();
        private string _timeStr = "";
        private string _dateStr = "";
        private string _weekStr = "";
        private string _machineCount = "5231";
        private readonly DispatcherTimer _timer = new(DispatcherPriority.Render);
        private readonly string[] _weekStrs = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

        public MainWindowViewModel()
        {
            StartGetTime();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public UserControl MonitorUC
        {
            get => _monitorUC;
            set
            {
                if (_monitorUC != value)
                {
                    _monitorUC = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MonitorUC)));
                }
            }
        }

        public string TimeStr
        {
            get => _timeStr;
            set
            {
                if (_timeStr != value)
                {
                    _timeStr = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeStr)));
                }
            }
        }

        public string DateStr
        {
            get => _dateStr;
            set
            {
                if (_dateStr != value)
                {
                    _dateStr = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateStr)));
                }
            }
        }

        public string WeekStr
        {
            get => _weekStr;
            set
            {
                if (_weekStr != value)
                {
                    _weekStr = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WeekStr)));
                }
            }
        }

        public string MachineCount
        {
            get => _machineCount;
            set
            {
                if (_machineCount != value)
                {
                    _machineCount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MachineCount)));
                }
            }
        }

        private void UpdateTime()
        {
            var curTime = DateTime.Now;
            var weekStr = _weekStrs[(int)curTime.DayOfWeek];

            TimeStr = curTime.ToString("HH:mm:ss");

            if (WeekStr != weekStr)
            {
                DateStr = curTime.ToString("yyyy-MM-dd");
                WeekStr = weekStr;
            }
        }

        private void StartGetTime()
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (_, _) => UpdateTime();
            _timer.Start();
        }

    }
}
