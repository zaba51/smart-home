using SmartHome.ControlPanel.AutoController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Devices
{
    public abstract class DeviceBase
    {
        protected IMediator? _mediator;

        public bool IsAutoMode { get; set; } = false;

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
            mediator.AddItem(this);
        }
    }
}
