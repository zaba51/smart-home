using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel.Service
{
    public interface IControlService
    {
        public Dictionary<string, List<IDevice>> Rooms { get; }
        public IDevice? SelectedDevice { get; }

        public void AddDevice (string room, IDevice device);
        public void AddSubscriber(ISubscriber subcsriber);

        public void SelectDevice(IDevice? device);
    }
}
