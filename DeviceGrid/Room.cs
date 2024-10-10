using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid
{
    public class Room
    {
        string Name { get; set; }
        Guid Guid { get; }

        public Room() { 
            Guid = Guid.NewGuid();
        }
    }
}
