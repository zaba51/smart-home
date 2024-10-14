using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel.AutoController.Handlers
{
    public interface IDeviceHandler
    {
        void SetNext(IDeviceHandler nextHandler);
        void Handle(IDevice device, List<IDevice> devices);
    }
}
