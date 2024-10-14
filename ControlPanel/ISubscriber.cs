using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.ControlPanel.Service;

namespace SmartHome.ControlPanel
{
    public interface ISubscriber
    {
        public void Update(IControlService service);
    }
}
