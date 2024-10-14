using SmartHome.DeviceGrid.Widget;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid
{
    public class Room
    {
        public string Name { get; set; }
        public Guid Guid { get; }

        public ObservableCollection<IWidget> Widgets { get; set; }

        public Room(string name)
        {
            Name = name;
            Widgets = new ObservableCollection<IWidget>();
            Guid = Guid.NewGuid();
        }
    }
}

