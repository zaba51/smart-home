using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel
{
    public interface ISubscriber
    {
        public void Update(IDevice? device);
    }
}
