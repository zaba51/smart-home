using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SmartHome.Devices
{
    public class Camera : DeviceBase, IDevice, INotifyPropertyChanged
    {
        public string Name { get; private set; }

        public bool IsRecording { 
            get {
                return _isRecording;
            }
            set
            {
                if (_isRecording == value)
                    return;

                _isRecording = value;
                if (_isRecording)
                {
                    StartRecording();
                }
                else
                {
                    StopRecording();
                }
            }
        }

        public TimeSpan RecordingDuration =>
            _isRecording && _recordingStartTime.HasValue
                ? DateTime.Now - _recordingStartTime.Value
                : TimeSpan.Zero;

        public string DownloadPath { get; private set; }

        private DateTime? _recordingStartTime;

        private bool _isRecording = false;

        private Clock? _clock = null;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Camera()
        {
            Name = "VideoCamera";
            DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CameraRecordings");
            Directory.CreateDirectory(DownloadPath);
        }

        public void OpenFolder()
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = DownloadPath,
                UseShellExecute = true,
                Verb = "open"
            });
        }
        private void StartRecording()
        {
            _recordingStartTime = DateTime.Now;
            _clock = new Clock();
            _clock.PropertyChanged += OnTick;
        }

        private void StopRecording()
        {
            _recordingStartTime = null;
            _clock = null;
        }
        private void OnTick(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                OnPropertyChanged(nameof(RecordingDuration));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string GetStatus()
        {
            throw new NotImplementedException();
        }
    }
}
