using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid.Widget.State
{
    internal class DefaultState : WidgetState
    {
        public DefaultState(IWidget widget) : base(widget)
        {
        }

        public override void OnClick()
        {
            widget.ChangeState(new SelectedState(widget));
        }
    }
}
