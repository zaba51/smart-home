using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    public class Camera : DeviceBase, IDevice
    {
        public string Name { get; private set; }

        private bool _isRecording = false;
        public bool IsRecording { 
            get {
                return _isRecording;
            }
            set
            {
                _isRecording = value;
            }
        }

        public bool DownloadPath { get; private set; }

        public Camera()
        {
            Name = "Video Camera";
        }

        public string GetStatus()
        {
            throw new NotImplementedException();
        }
    }
}
