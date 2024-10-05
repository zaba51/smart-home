using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid.Widget.State
{
    internal class DisabledState : WidgetState
    {
        public DisabledState(IWidget widget) : base(widget)
        {
        }

        public override void OnClick()
        {
            
        }
    }
}
