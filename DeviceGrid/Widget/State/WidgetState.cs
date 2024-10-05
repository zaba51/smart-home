using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.DeviceGrid.Widget.State
{
    public abstract class WidgetState
    {
        protected IWidget widget;

        public WidgetState(IWidget widget)
        {
            this.widget = widget;
        }

        public abstract void OnClick();
    }
}
