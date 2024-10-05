using SmartHome.DeviceGrid.Widget.State;
using SmartHome.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid.Widget
{
    public interface IWidget
    {
        public bool IsSelected { get;}
        public void Deselect();

        public IDevice GetComponent();

        public void ChangeState(WidgetState state);
    }
}
