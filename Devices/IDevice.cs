using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    public interface IDevice
    {
        string Name { get; }
        //void TurnOn();
        //void TurnOff();
        string GetStatus();
    }
}
